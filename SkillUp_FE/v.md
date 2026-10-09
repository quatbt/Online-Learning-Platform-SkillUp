Hệ thống đã được chuyển đổi hoàn toàn sang Code First và hoàn tất cấu hình Seed Data mẫu.

### 1. Những việc đã hoàn thành:

1. Khắc phục lỗi tồn đọng sau khi xóa module AI:
   • Dọn dẹp các using và reference cũ liên quan đến AI (GeminiOptions, SkillUp.Bussiness.Services, SkillUp.
   BusinessLogic.Services, SkillUp.DataAccess.Repositories).
   • Chuẩn hóa lại namespace cho VoucherTypeRepository, VoucherTypeService, SectionService, SectionsController,
   VoucherTypesController.
2. Chuyển sang EF Core Code First:
   • Đã reset và tạo Migration Code First chuẩn: InitialCreate.
   • Đổi database trong appsettings.json sang SkillUpDev để thử nghiệm Code First từ đầu mà không xung đột với dữ
   liệu cũ.
3. Cơ chế Auto-Migrate & Auto-Seed:
   • Đã tích hợp trong Program.cs:346-364: mỗi khi backend khởi động, EF Core sẽ tự động kiểm tra db.Database.
   MigrateAsync() và gọi DbSeeder.SeedAsync().
   • Seed data được thiết kế idempotent (chỉ insert nếu bảng chưa có dữ liệu) và quản lý chặt chẽ SET
   IDENTITY_INSERT cho các bảng có ID dạng int auto-increment.
4. Tạo dữ liệu Seed mẫu trong DbSeeder.cs:

| Nhóm dữ liệu                                                            | Chi tiết                                                                  |
| ----------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| Roles                                                                   | Admin (1), ContentModerator (2), SystemModerator (3), Lecturer (4),       |
| Student (5)                                                             |
| Accounts (Mật khẩu chung: Admin@123)                                    | • Admin: admin@skillup.vn• Content Mod: content.mod@skillup.vn• System    |
| Mod: system.mod@skillup.vn• Giảng viên: lecturer1@skillup.vn,           |
| lecturer2@skillup.vn• Học viên: student1@gmail.com, student2@gmail.com, |
| student3@gmail.com                                                      |
| Lecturers & Students                                                    | Thông tin hồ sơ giảng viên (ngân hàng, chức danh, tỷ lệ chia sẻ) và học   |
| viên                                                                    |
| Categories & SubCategories                                              | Lập trình (Web Frontend, Backend, Mobile), Thiết kế (UI/UX, Đồ họa), Kinh |
| doanh, Khoa học dữ liệu                                                 |
| Courses & Nội dung                                                      | 3 khóa học mẫu (HTML & CSS, ASP.NET Core Web API, Python cho Khoa học dữ  |
| liệu) kèm Sections và Lessons                                           |
| Vouchers & VoucherTypes                                                 | Voucher giảm 10% toàn sàn (WELCOME10), Voucher 20% theo khóa (HTML20)     |
| Banners & ForumCategories                                               | Banners trang chủ và các danh mục diễn đàn                                |
| Khác                                                                    | Carts, Enrollments, Ratings mẫu                                           |

### 2. Kết quả kiểm tra:

• Migration và seed data đã chạy thành công 100% vào database SkillUpDev.
• Đã test gọi API /api/Banner/active-banners trả về mã 200 với banner đã seed.
• Đã test API đăng nhập /api/Auth/login với tài khoản admin@skillup.vn / Admin@123 và nhận về JWT token thành công.
