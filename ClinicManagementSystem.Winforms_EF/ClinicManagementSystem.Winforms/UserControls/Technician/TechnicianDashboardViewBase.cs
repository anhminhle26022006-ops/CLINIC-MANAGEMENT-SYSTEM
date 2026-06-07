﻿﻿﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public enum TechnicianViewTarget
    {
        Overview,
        Requests,
        UploadMRI,
        UploadPDF,
        LabResult,
        Shifts,
        Records,
        SeederTool
    }

    public sealed class TechnicianNavigationEventArgs : EventArgs
    {
        public TechnicianNavigationEventArgs(TechnicianViewTarget target, int requestId = 0)
        {
            Target = target;
            RequestId = requestId;
        }

        public TechnicianViewTarget Target { get; }
        public int RequestId { get; }
    }

    public class TechnicianDashboardViewBase : UserControl
    {
        private const string RuntimeGeneratedViewTag = "__TechnicianRuntimeView";

        protected readonly Color primary = Color.FromArgb(47, 94, 240);
        protected readonly Color surface = Color.White;
        protected readonly Color pageBack = Color.FromArgb(247, 249, 252);
        protected readonly Color textMain = Color.FromArgb(17, 24, 39);
        protected readonly Color textMuted = Color.FromArgb(107, 114, 128);

        protected readonly PatientBUS patientBUS = new PatientBUS();
        protected readonly TechnicianRequestBUS requestBUS = new TechnicianRequestBUS();
        protected readonly TechnicianShiftBUS shiftBUS = new TechnicianShiftBUS();

        protected UserDTO currentUser;
        protected int activeRequestId;

        protected TechnicianDashboardViewBase()
        {
            Font = new Font("Segoe UI", 9F);
        }

        protected virtual Panel ContentPanel => null;

        public event EventHandler<TechnicianNavigationEventArgs> NavigateRequested;

        protected bool IsInVisualDesigner()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return true;
            }

            for (Control control = this; control != null; control = control.Parent)
            {
                if (control.Site?.DesignMode == true)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool ShouldRenderRuntimeView(Control designPreview = null)
        {
            if (designPreview != null)
            {
                designPreview.Visible = false;
            }

            if (!IsInVisualDesigner() && HasDesignerAuthoredContent(designPreview))
            {
                return false;
            }

            return !IsInVisualDesigner();
        }

        private bool HasDesignerAuthoredContent(Control designPreview)
        {
            if (ContentPanel == null)
            {
                return false;
            }

            foreach (Control control in ContentPanel.Controls)
            {
                if (ReferenceEquals(control, designPreview))
                {
                    continue;
                }

                if (!string.Equals(control.Tag as string, RuntimeGeneratedViewTag, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void Initialize(UserDTO user, int requestId = 0)
        {
            currentUser = user;
            activeRequestId = requestId;
        }

        protected void NavigateTo(TechnicianViewTarget target, int requestId = 0)
        {
            NavigateRequested?.Invoke(this, new TechnicianNavigationEventArgs(target, requestId));
        }

        protected FlowLayoutPanel BeginPage(string heading, string subheading)
        {
            ContentPanel.SuspendLayout();
            ContentPanel.Controls.Clear();

            var page = new FlowLayoutPanel
            {
                AutoScroll = true,
                BackColor = pageBack,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(24, 24, 24, 24),
                Tag = RuntimeGeneratedViewTag,
                WrapContents = false
            };

            var title = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = textMain,
                Height = 32,
                Text = heading,
                Width = PageWidth()
            };

            var subtitle = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textMuted,
                Height = 28,
                Margin = new Padding(0, 0, 0, 12),
                Text = subheading,
                Width = PageWidth()
            };

            page.Controls.Add(title);
            page.Controls.Add(subtitle);
            ContentPanel.Controls.Add(page);
            ContentPanel.ResumeLayout();
            return page;
        }

        protected int PageWidth()
        {
            return Math.Max(760, ContentPanel.ClientSize.Width - 70);
        }

        // ==========================================
        // UI HELPERS
        // ==========================================
        protected void AddRightBadge(RoundedPanel section, string text, Color back, Color fore)
        {
            section.Controls.Add(CreateBadge(text, back, fore, section.Width - 122, 24, 94, 26));
        }

        protected void AddShiftRow(RoundedPanel list, string col1, string col2, string col3, string col4, string col5, int y, bool header)
        {
            Color fore = header ? textMuted : textMain;
            FontStyle style = header ? FontStyle.Bold : FontStyle.Regular;
            if (header)
            {
                var back = new Panel { BackColor = Color.FromArgb(249, 250, 251), Location = new Point(0, y - 12), Size = new Size(list.Width, 44) };
                list.Controls.Add(back);
            }

            list.Controls.Add(CreateLabel(col1, 9F, style, fore, 18, y, 160, 24));
            list.Controls.Add(CreateLabel(col2, 9F, style, fore, 200, y, 90, 24));
            list.Controls.Add(CreateLabel(col3, 9F, style, fore, 310, y, 180, 24));
            list.Controls.Add(CreateLabel(col4, 9F, style, fore, 510, y, 160, 24));
            bool waiting = col5.Contains("Chờ") || col5.Contains("Cho");
            list.Controls.Add(CreateBadge(col5, waiting ? Color.FromArgb(254, 249, 195) : Color.FromArgb(220, 252, 231), waiting ? Color.FromArgb(161, 98, 7) : Color.FromArgb(34, 139, 74), list.Width - 140, y - 2, 110, 28));
        }

        protected Label CreateLabel(string text, float size, FontStyle style, Color color, int x, int y, int width, int height, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            return new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Text = text,
                TextAlign = align,
                BackColor = Color.Transparent
            };
        }

        protected TextBox CreateTextBox(string text, int x, int y, int width, int height)
        {
            TextBox tb = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(x, y),
                Size = new Size(width, height),
                Text = text
            };

            tb.Enter += (s, ev) =>
            {
                if (tb.Text.Contains("Tìm kiếm..."))
                {
                    tb.Text = "";
                    tb.ForeColor = textMain;
                }
            };

            tb.Leave += (s, ev) =>
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    tb.Text = text;
                    tb.ForeColor = Color.FromArgb(148, 163, 184);
                }
            };

            return tb;
        }

        protected Button CreateFlatButton(string text, Color fore, Color back, int x, int y, int width, int height)
        {
            var button = new Button
            {
                BackColor = back,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = fore,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Text = text,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        protected Label CreateBadge(string text, Color back, Color fore, int x, int y, int width, int height)
        {
            return new Label
            {
                AutoSize = false,
                BackColor = back,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = fore,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        protected RoundedPanel CreateIconBadge(string text, Color fore, int x, int y)
        {
            return CreateIconBadge(text, fore, x, y, Color.White);
        }

        protected RoundedPanel CreateIconBadge(string text, Color fore, int x, int y, Color fill)
        {
            var badge = new RoundedPanel
            {
                BorderColor = fill,
                CornerRadius = 8,
                FillColor = fill,
                Location = new Point(x, y),
                Size = new Size(48, 48)
            };
            badge.Controls.Add(CreateLabel(text, 8.5F, FontStyle.Bold, fore, 0, 0, 48, 48, ContentAlignment.MiddleCenter));
            return badge;
        }

        protected RoundedPanel CreateAvatar(string initial, int x, int y)
        {
            var avatar = new RoundedPanel
            {
                BorderColor = primary,
                CornerRadius = 24,
                FillColor = primary,
                Location = new Point(x, y),
                Size = new Size(48, 48)
            };
            avatar.Controls.Add(CreateLabel(initial, 11F, FontStyle.Bold, Color.White, 0, 0, 48, 48, ContentAlignment.MiddleCenter));
            return avatar;
        }

        protected RoundedPanel CreateStatCard(string number, string title, string icon, Color backColor, Color accent)
        {
            var card = new RoundedPanel
            {
                BorderColor = ControlPaint.Light(accent),
                CornerRadius = 12,
                Dock = DockStyle.Fill,
                FillColor = backColor,
                Margin = new Padding(0, 0, 14, 0)
            };
            card.Controls.Add(CreateIconBadge(icon, accent, 22, 22));
            card.Controls.Add(CreateLabel(number, 22F, FontStyle.Bold, accent, 24, 82, 120, 38));
            card.Controls.Add(CreateLabel(title, 9.5F, FontStyle.Regular, accent, 24, 118, 260, 24));
            return card;
        }

        protected RoundedPanel CreateActionCard(string title, string subtitle, string icon, Color backColor, Color accent)
        {
            var card = new RoundedPanel
            {
                BorderColor = backColor,
                CornerRadius = 8,
                Dock = DockStyle.Fill,
                FillColor = backColor,
                Margin = new Padding(0, 0, 14, 0),
                Cursor = Cursors.Hand
            };
            card.Controls.Add(CreateIconBadge(icon, accent, 22, 18));
            card.Controls.Add(CreateLabel(title, 10.5F, FontStyle.Bold, textMain, 22, 62, 210, 28));
            card.Controls.Add(CreateLabel(subtitle, 9F, FontStyle.Bold, textMuted, 22, 88, 210, 22));
            return card;
        }

        protected RoundedPanel CreateMiniStat(string title, string value, Color color)
        {
            var card = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 14, 0)
            };
            card.Controls.Add(CreateLabel(title, 9.5F, FontStyle.Regular, textMuted, 16, 20, 180, 22));
            card.Controls.Add(CreateLabel(value, 18F, FontStyle.Bold, color, 16, 48, 80, 32));
            return card;
        }

        protected RoundedPanel CreateStatRowCard(string title, string value, string icon, Color iconBack, Color accent)
        {
            var card = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 14, 0)
            };
            card.Controls.Add(CreateIconBadge(icon, accent, 22, 28, iconBack));
            card.Controls.Add(CreateLabel(title, 10F, FontStyle.Regular, textMuted, 92, 30, 210, 24));
            card.Controls.Add(CreateLabel(value, 18F, FontStyle.Bold, textMain, 92, 58, 160, 34));
            return card;
        }

        protected RoundedPanel CreateSmallPatient(string name, string service, string doctor, string badge, Color badgeBack, Color badgeFore, int y)
        {
            var row = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = Color.FromArgb(249, 250, 251),
                Location = new Point(18, y),
                Size = new Size(PageWidth() / 2 - 58, 98)
            };
            row.Controls.Add(CreateLabel(name, 10F, FontStyle.Bold, textMain, 14, 16, 220, 22));
            row.Controls.Add(CreateLabel(service, 9F, FontStyle.Regular, textMuted, 14, 40, 220, 20));
            row.Controls.Add(CreateLabel(doctor, 8.5F, FontStyle.Regular, textMuted, 14, 70, 240, 20));
            row.Controls.Add(CreateBadge(badge, badgeBack, badgeFore, row.Width - 108, 34, 86, 28));
            return row;
        }

        protected TableLayoutPanel CreateGrid(int columns, int height)
        {
            return CreateGrid(columns, height, PageWidth());
        }

        protected TableLayoutPanel CreateGrid(int columns, int height, int width)
        {
            var grid = new TableLayoutPanel
            {
                ColumnCount = columns,
                Height = height,
                Margin = new Padding(0, 0, 0, 18),
                RowCount = 1,
                Width = width
            };

            for (int i = 0; i < columns; i++)
            {
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columns));
            }

            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            return grid;
        }

        protected RoundedPanel CreateSection(string title, int height, bool link = false)
        {
            var section = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = height,
                Margin = new Padding(0, 0, 0, 18),
                Width = PageWidth()
            };
            section.Controls.Add(CreateLabel(title, 13F, FontStyle.Bold, textMain, 18, 18, 420, 28));
            if (link)
            {
                section.Controls.Add(CreateLabel("Xem tất cả", 9F, FontStyle.Bold, primary, section.Width - 100, 22, 80, 22, ContentAlignment.MiddleRight));
            }

            return section;
        }

        protected class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    
    }
}

