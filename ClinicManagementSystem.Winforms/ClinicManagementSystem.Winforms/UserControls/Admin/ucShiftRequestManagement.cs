using BUS.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftRequestManagement : UserControl
    {
        // UI chỉ gọi BUS - không gọi DAL hay DatabaseHelper trực tiếp
        private readonly ShiftRequestBUS _bus = new ShiftRequestBUS();

        public ucShiftRequestManagement()
        {
            InitializeComponent();
            this.Load += (s, e) =>
            {
                // Force KPI resize ngay khi load
                ForceResize();
                LoadData();
            };
            this.Resize += (s, e) => ForceResize();
        }

        private void ForceResize()
        {
            int w = this.ClientSize.Width - this.Padding.Horizontal;
            if (w <= 0) return;
            kpiFlow.Width = w;
            var cards = new[] { cardTotal, cardPending, cardApproved, cardRejected };
            int gap = 16, cardW = (w - gap * 3) / 4;
            if (cardW <= 0) return;
            foreach (var card in cards) { card.Width = cardW; card.Height = 120; card.Margin = new System.Windows.Forms.Padding(0, 0, gap, 0); }
        }

        public void LoadData()
        {
            try
            {
                LoadKpiCards();
                LoadWarningBanner();
                ShowTabOverview();
                SetActiveTab(btnTabOverview);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ShiftRequest error: " + ex.Message);
            }
        }

        // ── KPI Cards ─────────────────────────────────────────────────
        private void LoadKpiCards()
        {
            int total = _bus.GetTotalShifts();
            int pending = _bus.TableExists() ? _bus.CountPending() : 0;
            int approved = _bus.TableExists() ? _bus.CountApproved() : 0;
            int rejected = _bus.TableExists() ? _bus.CountRejected() : 0;

            SetKpi(cardTotal, total.ToString(), "+12% so với tháng trước");
            SetKpi(cardPending, pending.ToString(), "Yêu cầu đổi ca cần xử lý");
            SetKpi(cardApproved, approved.ToString(), "Tháng này");
            SetKpi(cardRejected, rejected.ToString(), "Tháng này");

            // Badge trên tab Duyệt đổi ca
            lblBadge.Text = pending.ToString();
            lblBadge.Visible = pending > 0;
        }

        private void SetKpi(Panel card, string value, string sub)
        {
            if (card == null) return;
            foreach (Control c in card.Controls)
                if (c is Label lbl)
                {
                    if (lbl.Tag?.ToString() == "value") lbl.Text = value;
                    if (lbl.Tag?.ToString() == "sub") lbl.Text = sub;
                }
        }

        // ── Warning Banner ────────────────────────────────────────────
        private void LoadWarningBanner()
        {
            int pending = _bus.TableExists() ? _bus.CountPending() : 0;
            panelWarning.Visible = pending > 0;
            if (pending > 0)
            {
                foreach (Control c in panelWarning.Controls)
                    if (c is Label lbl && lbl.Tag?.ToString() == "main")
                        lbl.Text = $"⚠  Có {pending} yêu cầu đổi ca đang chờ duyệt";
            }
        }

        // ── Tab switching ─────────────────────────────────────────────
        private void btnTabOverview_Click(object sender, EventArgs e)
        { SetActiveTab(btnTabOverview); ShowTabOverview(); }

        private void btnTabApproval_Click(object sender, EventArgs e)
        { SetActiveTab(btnTabApproval); ShowTabApproval(); }

        private void btnTabSchedule_Click(object sender, EventArgs e)
        { SetActiveTab(btnTabSchedule); ShowTabSchedule(); }

        private void SetActiveTab(Button active)
        {
            foreach (var b in new[] { btnTabOverview, btnTabApproval, btnTabSchedule })
            {
                b.ForeColor = Color.FromArgb(107, 114, 128);
                b.Tag = null;
            }
            active.ForeColor = Color.FromArgb(37, 99, 235);
            active.Tag = "active";
            panelTabs.Invalidate();
        }

        // ── Tab: Tổng quan ────────────────────────────────────────────
        private void ShowTabOverview()
        {
            panelTabContent.Controls.Clear();

            // Dùng TableLayoutPanel 2 rows để tránh Dock overlap
            var tbl = new System.Windows.Forms.TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                BackColor = Color.FromArgb(247, 249, 252),
                Padding = new Padding(0, 8, 0, 16),
                AutoScroll = true
            };
            tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 176F)); // stats
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F)); // activity

            // ── Row 0: Thống kê ───────────────────────────────────────
            var statsCard = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 0, 12) };
            statsCard.Paint += (s, e2) =>
            {
                using var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1);
                e2.Graphics.DrawRectangle(pen, 0, 0, statsCard.Width - 1, statsCard.Height - 1);
            };
            statsCard.Controls.Add(new Label
            {
                Text = "Thống kê ca làm việc",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Dock = DockStyle.Top,
                Height = 44,
                Padding = new Padding(16, 12, 0, 0)
            });

            var miniPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(16, 4, 16, 8) };
            var todayCard = BuildMiniStatCard("Ca hôm nay", _bus.GetTodayShifts().ToString(), "Đang hoạt động", Color.FromArgb(37, 99, 235));
            var upcomCard = BuildMiniStatCard("Ca sắp tới", _bus.GetUpcomingShifts().ToString(), "7 ngày tới", Color.FromArgb(5, 150, 105));
            miniPanel.Controls.Add(todayCard);
            miniPanel.Controls.Add(upcomCard);
            miniPanel.Resize += (s2, e2) =>
            {
                int hw = (miniPanel.ClientSize.Width - miniPanel.Padding.Horizontal - 12) / 2;
                if (hw <= 0) return;
                todayCard.Size = new Size(hw, 96); todayCard.Location = new Point(0, 0);
                upcomCard.Size = new Size(hw, 96); upcomCard.Location = new Point(hw + 12, 0);
            };
            statsCard.Controls.Add(miniPanel);
            tbl.Controls.Add(statsCard, 0, 0);

            // ── Row 1: Hoạt động gần đây ─────────────────────────────
            var actCard = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 0, 0) };
            actCard.Paint += (s, e2) =>
            {
                using var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1);
                e2.Graphics.DrawRectangle(pen, 0, 0, actCard.Width - 1, actCard.Height - 1);
            };
            actCard.Controls.Add(new Label
            {
                Text = "Hoạt động gần đây",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Dock = DockStyle.Top,
                Height = 44,
                Padding = new Padding(16, 12, 0, 0)
            });

            var actInner = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, AutoScroll = true, Padding = new Padding(16, 4, 16, 8) };
            // Load data trực tiếp - không phụ thuộc vào Resize event
            LoadActivityItems(actInner);
            actCard.Controls.Add(actInner);
            tbl.Controls.Add(actCard, 0, 1);

            panelTabContent.Controls.Add(tbl);
        }



        private void LoadActivityItems(Panel container)
        {
            List<ShiftRequestDTO> requests = _bus.TableExists() ? _bus.GetAll() : new List<ShiftRequestDTO>();

            if (requests.Count == 0)
            {
                container.Controls.Add(new Label
                {
                    Text = "Chưa có hoạt động nào",
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Dock = DockStyle.Top,
                    Height = 36,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                });
                return;
            }

            var items = new List<Panel>();
            foreach (var req in requests)
            {
                Color statusFg = req.Status == "Pending" ? Color.FromArgb(161, 98, 7) :
                                 req.Status == "Approved" ? Color.FromArgb(22, 163, 74) :
                                                             Color.FromArgb(220, 38, 38);
                Color statusBg = req.Status == "Pending" ? Color.FromArgb(254, 249, 195) :
                                 req.Status == "Approved" ? Color.FromArgb(220, 252, 231) :
                                                             Color.FromArgb(254, 226, 226);
                string statusText = req.Status == "Pending" ? "Chờ duyệt" :
                                    req.Status == "Approved" ? "Đã duyệt" : "Từ chối";

                var item = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Color.White };
                item.Paint += (s, e2) =>
                {
                    using var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1);
                    e2.Graphics.DrawLine(pen, 0, item.Height - 1, item.Width, item.Height - 1);
                };
                item.Controls.Add(new Label
                {
                    Text = req.RequesterName + " yêu cầu đổi ca",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Location = new Point(8, 8),
                    AutoSize = true
                });
                item.Controls.Add(new Label
                {
                    Text = req.RequestCode + " • " + req.CreatedAt.ToString("HH:mm:ss d/M/yyyy"),
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Location = new Point(8, 32),
                    AutoSize = true
                });
                var lblSt = new Label
                {
                    Text = statusText,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    ForeColor = statusFg,
                    BackColor = statusBg,
                    Padding = new Padding(8, 3, 8, 3),
                    AutoSize = true,
                    Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                    Location = new Point(container.Width > 120 ? container.Width - 120 : 200, 20)
                };
                item.Controls.Add(lblSt);
                items.Add(item);
            }

            for (int i = items.Count - 1; i >= 0; i--)
                container.Controls.Add(items[i]);
        }

        private Panel BuildMiniStatCard(string title, string value, string sub, Color accent)
        {
            var card = new Panel { Size = new Size(380, 100), BackColor = Color.White, Margin = new Padding(0, 0, 16, 0) };
            card.Paint += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };
            card.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(55, 65, 81), Location = new Point(16, 12), AutoSize = true });
            card.Controls.Add(new Label { Text = value, Font = new Font("Segoe UI", 28F, FontStyle.Bold), ForeColor = accent, Location = new Point(16, 34), AutoSize = true });
            card.Controls.Add(new Label { Text = sub, Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(107, 114, 128), Location = new Point(16, 76), AutoSize = true });
            return card;
        }

        private FlowLayoutPanel BuildActivityFeed()
        {
            var flow = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(16, 8, 16, 8)
            };
            flow.Resize += (s, e) => { foreach (Control c in flow.Controls) c.Width = flow.Width - 36; };

            List<ShiftRequestDTO> requests = _bus.TableExists() ? _bus.GetAll() : new List<ShiftRequestDTO>();

            if (requests.Count == 0)
            {
                flow.Controls.Add(new Label
                {
                    Text = "Chưa có hoạt động nào",
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    AutoSize = true,
                    Margin = new Padding(0, 16, 0, 0)
                });
                return flow;
            }

            foreach (var req in requests)
            {
                Color statusFg = req.Status == "Pending" ? Color.FromArgb(161, 98, 7) :
                                 req.Status == "Approved" ? Color.FromArgb(22, 163, 74) :
                                                             Color.FromArgb(220, 38, 38);
                Color statusBg = req.Status == "Pending" ? Color.FromArgb(254, 249, 195) :
                                 req.Status == "Approved" ? Color.FromArgb(220, 252, 231) :
                                                             Color.FromArgb(254, 226, 226);
                string statusText = req.Status == "Pending" ? "Chờ duyệt" :
                                    req.Status == "Approved" ? "Đã duyệt" : "Từ chối";

                flow.Controls.Add(BuildActivityItem(
                    req.RequesterName + " yêu cầu đổi ca",
                    req.RequestCode + " • " + req.CreatedAt.ToString("HH:mm:ss d/M/yyyy"),
                    statusText, statusFg, statusBg));
            }
            return flow;
        }

        private Panel BuildActivityItem(string title, string sub, string status, Color statusFg, Color statusBg)
        {
            var item = new Panel { Height = 64, BackColor = Color.White, Margin = new Padding(0, 0, 0, 1) };
            item.Paint += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1);
                e.Graphics.DrawLine(pen, 0, item.Height - 1, item.Width, item.Height - 1);
            };

            item.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(17, 24, 39), Location = new Point(8, 8), AutoSize = true });
            item.Controls.Add(new Label { Text = sub, Font = new Font("Segoe UI", 8.5F), ForeColor = Color.FromArgb(107, 114, 128), Location = new Point(8, 32), AutoSize = true });

            var lblSt = new Label
            {
                Text = status,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = statusFg,
                BackColor = statusBg,
                Padding = new Padding(8, 3, 8, 3),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(item.Width - 120, 20)
            };
            item.Controls.Add(lblSt);
            return item;
        }

        // ── Tab: Duyệt đổi ca ─────────────────────────────────────────
        private void ShowTabApproval()
        {
            panelTabContent.Controls.Clear();

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(247, 249, 252),
                Padding = new Padding(0, 8, 0, 16)
            };

            List<ShiftRequestDTO> requests = _bus.TableExists() ? _bus.GetAll() : new List<ShiftRequestDTO>();

            // Header label
            var hdr = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.Transparent };
            hdr.Controls.Add(new Label
            {
                Text = $"Danh sách yêu cầu ({requests.Count})",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            });

            if (requests.Count == 0)
            {
                var empty = new Label
                {
                    Text = "Chưa có yêu cầu đổi ca nào",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Dock = DockStyle.Top,
                    Height = 40,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                };
                scroll.Controls.Add(empty);
                scroll.Controls.Add(hdr);
            }
            else
            {
                // Add cards in reverse for DockStyle.Top
                var cards = new System.Collections.Generic.List<Panel>();
                foreach (var req in requests)
                    cards.Add(BuildRequestCard(req, null));

                for (int i = cards.Count - 1; i >= 0; i--)
                {
                    var sp2 = new Panel { Dock = DockStyle.Top, Height = 16, BackColor = Color.Transparent };
                    scroll.Controls.Add(sp2);
                    cards[i].Dock = DockStyle.Top;
                    scroll.Controls.Add(cards[i]);
                }
                scroll.Controls.Add(hdr);
            }

            panelTabContent.Controls.Add(scroll);
        }

        private Panel BuildRequestCard(ShiftRequestDTO req, Panel parent)
        {
            Color statusFg = req.Status == "Pending" ? Color.FromArgb(161, 98, 7) :
                             req.Status == "Approved" ? Color.FromArgb(22, 163, 74) :
                                                         Color.FromArgb(220, 38, 38);
            Color statusBg = req.Status == "Pending" ? Color.FromArgb(254, 249, 195) :
                             req.Status == "Approved" ? Color.FromArgb(220, 252, 231) :
                                                         Color.FromArgb(254, 226, 226);
            string statusText = req.Status == "Pending" ? "Chờ duyệt" :
                                req.Status == "Approved" ? "Đã duyệt" : "Từ chối";

            int cardH = req.Status == "Pending" ? 340 : 290;
            var card = new Panel { Height = cardH, BackColor = Color.White, Margin = new Padding(0, 0, 0, 16), Padding = new Padding(20) };
            card.Paint += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };

            // Title row
            card.Controls.Add(new Label { Text = "Yêu cầu đổi ca", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(17, 24, 39), Location = new Point(20, 16), AutoSize = true });
            card.Controls.Add(new Label
            {
                Text = $"Mã yêu cầu: {req.RequestCode} • Gửi lúc: {req.CreatedAt:HH:mm:ss d/M/yyyy}",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(20, 42),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = statusText,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = statusFg,
                BackColor = statusBg,
                Padding = new Padding(10, 4, 10, 4),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(card.Width - 130, 16)
            });

            // People row
            var panelPeople = new Panel { Height = 80, Location = new Point(20, 72), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            var cardReq = BuildPersonCard("Người yêu cầu", req.RequesterName, req.RequesterRole, Color.FromArgb(219, 234, 254), Color.FromArgb(37, 99, 235));
            var cardRep = BuildPersonCard("Người thay thế", string.IsNullOrEmpty(req.ReplacerName) ? "Chưa xác định" : req.ReplacerName, req.ReplacerRole, Color.FromArgb(209, 250, 229), Color.FromArgb(5, 150, 105));
            panelPeople.Controls.AddRange(new Control[] { cardReq, cardRep });
            panelPeople.Resize += (s2, e2) =>
            {
                int hw2 = (panelPeople.Width - 8) / 2;
                if (hw2 <= 0) return;
                cardReq.Width = hw2; cardReq.Height = 74;
                cardRep.Width = hw2; cardRep.Height = 74; cardRep.Location = new Point(hw2 + 8, 0);
            };
            card.Controls.Add(panelPeople);

            // Reason
            if (!string.IsNullOrEmpty(req.Reason))
            {
                card.Controls.Add(new Label
                {
                    Text = "💬  Lý do: " + req.Reason,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    Location = new Point(20, 164),
                    AutoSize = true,
                    MaximumSize = new Size(card.Width - 40, 0)
                });
            }

            // Approve/Reject buttons for Pending
            if (req.Status == "Pending")
            {
                int reqId = req.RequestID;
                var btnReject = new Button
                {
                    Text = "⊗  Từ chối",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(220, 38, 38),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(200, 46),
                    Location = new Point(20, 258),
                    Cursor = Cursors.Hand
                };
                btnReject.FlatAppearance.BorderColor = Color.FromArgb(220, 38, 38);
                btnReject.Click += (s, e) =>
                {
                    if (_bus.Reject(reqId, "Admin"))
                    { LoadData(); ShowTabApproval(); SetActiveTab(btnTabApproval); }
                };

                var btnApprove = new Button
                {
                    Text = "✓  Phê duyệt",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(22, 163, 74),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(200, 46),
                    Location = new Point(232, 258),
                    Cursor = Cursors.Hand
                };
                btnApprove.FlatAppearance.BorderSize = 0;
                btnApprove.Click += (s, e) =>
                {
                    if (_bus.Approve(reqId, "Admin"))
                    { LoadData(); ShowTabApproval(); SetActiveTab(btnTabApproval); }
                };
                card.Controls.AddRange(new Control[] { btnReject, btnApprove });
            }

            return card;
        }

        private Panel BuildPersonCard(string role, string name, string dept, Color bg, Color accent)
        {
            var p = new Panel { BackColor = bg, Location = new Point(0, 0), Padding = new Padding(12) };
            p.Controls.Add(new Label { Text = "👤  " + role, Font = new Font("Segoe UI", 8.5F), ForeColor = accent, Location = new Point(12, 8), AutoSize = true });
            p.Controls.Add(new Label { Text = name, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(17, 24, 39), Location = new Point(12, 28), AutoSize = true });
            p.Controls.Add(new Label { Text = dept, Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(107, 114, 128), Location = new Point(12, 52), AutoSize = true });
            return p;
        }

        // ── Tab: Lịch làm việc ────────────────────────────────────────
        private void ShowTabSchedule()
        {
            panelTabContent.Controls.Clear();
            var shiftUC = new ucShiftManagement();
            shiftUC.Dock = DockStyle.Fill;
            panelTabContent.Controls.Add(shiftUC);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private Panel BuildWhiteCard(string title, int height)
        {
            var card = new Panel { Height = height, BackColor = Color.White, Margin = new Padding(0, 0, 0, 16) };
            card.Paint += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Dock = DockStyle.Top,
                Height = 44,
                Padding = new Padding(16, 12, 0, 0)
            });
            return card;
        }

        private void btnWarningAction_Click(object sender, EventArgs e)
        { SetActiveTab(btnTabApproval); ShowTabApproval(); }
    }
}