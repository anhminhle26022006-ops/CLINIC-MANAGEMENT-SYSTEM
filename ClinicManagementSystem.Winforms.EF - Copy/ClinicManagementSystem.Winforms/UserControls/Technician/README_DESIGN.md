# Technician UI Design Map

Các màn chính đã có Designer sẵn:

- `ucTechnicianOverview`: tổng quan kỹ thuật viên.
- `ucTechnicianRequests`: màn `Xét nghiệm - Chẩn đoán`.
- `ucPatientRecords`: màn `Hồ Sơ Bệnh Án`.
- `ucTechnicianShifts`: màn lịch/ca trực.
- `ucTechnicianLabResult`: nhập chỉ số xét nghiệm.
- `ucTechnicianUploadMri`: upload hình phim MRI/X-Ray.
- `ucTechnicianUploadPdf`: upload PDF chẩn đoán.

Các box/dòng runtime đã được tách thành UserControl riêng để mở bằng Visual Studio Designer:

- `ucTechnicianRequestGroupCard`: card lớn của một bệnh nhân trong màn `Xét nghiệm - Chẩn đoán`.
- `ucTechnicianRequestServiceRow`: từng dòng dịch vụ trong card lớn, gồm tên dịch vụ, ghi chú, ưu tiên, trạng thái, nút `Xem` / `Xử lý`.
- `ucPatientRecordRow`: từng bệnh nhân trong danh sách bên trái của màn `Hồ Sơ Bệnh Án`.
- `ucPatientHistoryResultCard`: card lịch sử kết quả trong màn `Hồ Sơ Bệnh Án` sau khi bấm `Xem`.
- `ucTechnicianQueueRow`: dòng nhỏ trong `Yêu cầu Xét nghiệm` và `Hàng đợi Chụp ảnh` ở tổng quan.
- `ucTechnicianShiftTableRow`: từng dòng trong `Danh sách ca trực chi tiết`.

Muốn kéo dài text, badge, button:

1. Mở file `.cs` của UserControl cần sửa.
2. Chuột phải, chọn `View Designer`.
3. Kéo label/button/panel trong Designer.
4. Build lại project và chạy lại app.

Lưu ý quan trọng:

- Danh sách dữ liệu vẫn được sinh lúc runtime, nên Designer chỉ hiện mẫu của 1 box hoặc 1 dòng.
- Nếu muốn sửa bố cục bên trong box, mở các UserControl nhỏ ở trên.
- Nếu muốn sửa khoảng cách giữa các box, mở màn chính như `ucTechnicianRequests`, `ucPatientRecords`, `ucTechnicianOverview`, `ucTechnicianShifts`.
- Chiều cao của `ucTechnicianRequestServiceRow`, `ucPatientRecordRow`, `ucPatientHistoryResultCard`, `ucTechnicianQueueRow`, `ucTechnicianShiftTableRow` đã được runtime dùng theo kích thước trong Designer, nên kéo cao/thấp trong Designer sẽ có tác dụng khi chạy.
