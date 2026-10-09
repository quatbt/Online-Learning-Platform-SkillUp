using Microsoft.EntityFrameworkCore;
using SkillUp.BussinessObjects.Models;

namespace SkillUp.Data;

/// <summary>
/// Seeds initial / sample data into the database (idempotent).
/// Only runs when the tables are empty to avoid duplicates.
/// </summary>
public static class DbSeeder
{
    // Fixed GUIDs so every run produces the same IDs
    private static readonly Guid AdminAccountId       = new("11111111-1111-1111-1111-111111111101");
    private static readonly Guid ModAccountId         = new("11111111-1111-1111-1111-111111111102");
    private static readonly Guid SysModAccountId      = new("11111111-1111-1111-1111-111111111103");
    private static readonly Guid Lecturer1AccountId   = new("11111111-1111-1111-1111-111111111104");
    private static readonly Guid Lecturer2AccountId   = new("11111111-1111-1111-1111-111111111105");
    private static readonly Guid Student1AccountId    = new("11111111-1111-1111-1111-111111111106");
    private static readonly Guid Student2AccountId    = new("11111111-1111-1111-1111-111111111107");
    private static readonly Guid Student3AccountId    = new("11111111-1111-1111-1111-111111111108");

    private static readonly Guid Lecturer1Id          = new("22222222-2222-2222-2222-222222222201");
    private static readonly Guid Lecturer2Id          = new("22222222-2222-2222-2222-222222222202");
    private static readonly Guid Student1Id           = new("33333333-3333-3333-3333-333333333301");
    private static readonly Guid Student2Id           = new("33333333-3333-3333-3333-333333333302");
    private static readonly Guid Student3Id           = new("33333333-3333-3333-3333-333333333303");

    private static readonly Guid Course1Id            = new("44444444-4444-4444-4444-444444444401");
    private static readonly Guid Course2Id            = new("44444444-4444-4444-4444-444444444402");
    private static readonly Guid Course3Id            = new("44444444-4444-4444-4444-444444444403");

    private static readonly Guid Section1Id           = new("55555555-5555-5555-5555-555555555501");
    private static readonly Guid Section2Id           = new("55555555-5555-5555-5555-555555555502");
    private static readonly Guid Section3Id           = new("55555555-5555-5555-5555-555555555503");
    private static readonly Guid Section4Id           = new("55555555-5555-5555-5555-555555555504");

    private static readonly Guid Lesson1Id            = new("66666666-6666-6666-6666-666666666601");
    private static readonly Guid Lesson2Id            = new("66666666-6666-6666-6666-666666666602");
    private static readonly Guid Lesson3Id            = new("66666666-6666-6666-6666-666666666603");
    private static readonly Guid Lesson4Id            = new("66666666-6666-6666-6666-666666666604");
    private static readonly Guid Lesson5Id            = new("66666666-6666-6666-6666-666666666605");

    private static readonly Guid Cart1Id              = new("77777777-7777-7777-7777-777777777701");
    private static readonly Guid Cart2Id              = new("77777777-7777-7777-7777-777777777702");
    private static readonly Guid Cart3Id              = new("77777777-7777-7777-7777-777777777703");

    /// <summary>
    /// Helper: mở connection, SET IDENTITY_INSERT ON, SaveChanges, SET OFF.
    /// Giữ connection mở liên tục để SQL Server nhận IDENTITY_INSERT trong cùng session.
    /// </summary>
    private static async Task SaveWithIdentityInsertAsync(SkillUpContext db, string tableName)
    {
        var conn = db.Database.GetDbConnection();
        var wasOpen = conn.State == System.Data.ConnectionState.Open;
        if (!wasOpen) await conn.OpenAsync();
        try
        {
            await db.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT [{tableName}] ON");
            await db.SaveChangesAsync();
            await db.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT [{tableName}] OFF");
        }
        finally
        {
            if (!wasOpen) await conn.CloseAsync();
        }
    }

    public static async Task SeedAsync(SkillUpContext db)
    {
        // ── 1. Roles ────────────────────────────────────────────────────────────
        if (!await db.Roles.AnyAsync())
        {
            db.Roles.AddRange(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "ContentModerator" },
                new Role { Id = 3, Name = "SystemModerator" },
                new Role { Id = 4, Name = "Lecturer" },
                new Role { Id = 5, Name = "Student" }
            );
            await SaveWithIdentityInsertAsync(db, "Role");
        }

        // ── 2. Accounts ─────────────────────────────────────────────────────────
        if (!await db.Accounts.AnyAsync())
        {
            // BCrypt hash of "12345678@Abc" — mật khẩu mặc định cho tất cả account seed
            var pwHash = BCrypt.Net.BCrypt.HashPassword("12345678@Abc");

            db.Accounts.AddRange(
                new Account
                {
                    Id        = AdminAccountId,
                    Email     = "admin@skillup.vn",
                    Password  = pwHash,
                    Fullname  = "SkillUp Admin",
                    Status    = "Active",
                    RoleId    = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                    Id        = ModAccountId,
                    Email     = "content.mod@skillup.vn",
                    Password  = pwHash,
                    Fullname  = "Nguyễn Content Mod",
                    Status    = "Active",
                    RoleId    = 2,
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                    Id        = SysModAccountId,
                    Email     = "system.mod@skillup.vn",
                    Password  = pwHash,
                    Fullname  = "Trần System Mod",
                    Status    = "Active",
                    RoleId    = 3,
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                    Id        = Lecturer1AccountId,
                    Email     = "lecturer1@skillup.vn",
                    Password  = pwHash,
                    Fullname  = "Lê Văn Giảng",
                    Status    = "Active",
                    RoleId    = 4,
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                    Id        = Lecturer2AccountId,
                    Email     = "lecturer2@skillup.vn",
                    Password  = pwHash,
                    Fullname  = "Phạm Thị Dạy",
                    Status    = "Active",
                    RoleId    = 4,
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                    Id        = Student1AccountId,
                    Email     = "student1@gmail.com",
                    Password  = pwHash,
                    Fullname  = "Nguyễn Văn An",
                    Status    = "Active",
                    RoleId    = 5,
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                    Id        = Student2AccountId,
                    Email     = "student2@gmail.com",
                    Password  = pwHash,
                    Fullname  = "Trần Thị Bình",
                    Status    = "Active",
                    RoleId    = 5,
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                    Id        = Student3AccountId,
                    Email     = "student3@gmail.com",
                    Password  = pwHash,
                    Fullname  = "Phạm Văn Cường",
                    Status    = "Active",
                    RoleId    = 5,
                    CreatedAt = DateTime.UtcNow
                }
            );
            await db.SaveChangesAsync(); // Account PK = Guid → không cần IDENTITY_INSERT
        }

        // ── 3. Lecturers ────────────────────────────────────────────────────────
        if (!await db.Lecturers.AnyAsync())
        {
            db.Lecturers.AddRange(
                new Lecturer
                {
                    Id         = Lecturer1Id,
                    AccountId  = Lecturer1AccountId,
                    Title      = "Kỹ sư phần mềm cao cấp",
                    Profession = "Lập trình Web",
                    BankNumber = "0123456789",
                    BankName   = "Vietcombank",
                    ReceiverName = "LE VAN GIANG",
                    Percentage = 70
                },
                new Lecturer
                {
                    Id         = Lecturer2Id,
                    AccountId  = Lecturer2AccountId,
                    Title      = "Thạc sĩ CNTT",
                    Profession = "Khoa học dữ liệu",
                    BankNumber = "9876543210",
                    BankName   = "Techcombank",
                    ReceiverName = "PHAM THI DAY",
                    Percentage = 70
                }
            );
            await db.SaveChangesAsync();
        }

        // ── 4. Students ─────────────────────────────────────────────────────────
        if (!await db.Students.AnyAsync())
        {
            db.Students.AddRange(
                new Student { Id = Student1Id, AccountId = Student1AccountId },
                new Student { Id = Student2Id, AccountId = Student2AccountId },
                new Student { Id = Student3Id, AccountId = Student3AccountId }
            );
            await db.SaveChangesAsync();
        }

        // ── 5. Categories & SubCategories ───────────────────────────────────────
        if (!await db.Categories.AnyAsync())
        {
            db.Categories.AddRange(
                new Category { Id = 1, Name = "Lập trình",        IsActive = true },
                new Category { Id = 2, Name = "Thiết kế",         IsActive = true },
                new Category { Id = 3, Name = "Kinh doanh",       IsActive = true },
                new Category { Id = 4, Name = "Khoa học dữ liệu", IsActive = true }
            );
            await SaveWithIdentityInsertAsync(db, "Category");
        }

        if (!await db.SubCategories.AnyAsync())
        {
            db.SubCategories.AddRange(
                new SubCategory { Id = 1, CategoryId = 1, Name = "Web Frontend",       IsActive = true },
                new SubCategory { Id = 2, CategoryId = 1, Name = "Web Backend",        IsActive = true },
                new SubCategory { Id = 3, CategoryId = 1, Name = "Mobile",             IsActive = true },
                new SubCategory { Id = 4, CategoryId = 2, Name = "UI/UX Design",       IsActive = true },
                new SubCategory { Id = 5, CategoryId = 2, Name = "Đồ họa",             IsActive = true },
                new SubCategory { Id = 6, CategoryId = 3, Name = "Marketing",          IsActive = true },
                new SubCategory { Id = 7, CategoryId = 4, Name = "Machine Learning",   IsActive = true },
                new SubCategory { Id = 8, CategoryId = 4, Name = "Python cho Data",    IsActive = true }
            );
            await SaveWithIdentityInsertAsync(db, "SubCategory");
        }

        // ── 6. Forum Categories ─────────────────────────────────────────────────
        if (!await db.ForumCategories.AnyAsync())
        {
            db.ForumCategories.AddRange(
                new ForumCategory { Id = 1, Name = "Hỏi đáp chung",       IsActive = true },
                new ForumCategory { Id = 2, Name = "Lập trình Web",        IsActive = true },
                new ForumCategory { Id = 3, Name = "Khoa học dữ liệu",    IsActive = true },
                new ForumCategory { Id = 4, Name = "Thiết kế",             IsActive = true },
                new ForumCategory { Id = 5, Name = "Kinh nghiệm học tập",  IsActive = true }
            );
            await SaveWithIdentityInsertAsync(db, "ForumCategory");
        }

        // ── 7. Banners ──────────────────────────────────────────────────────────
        if (!await db.Banners.AnyAsync())
        {
            db.Banners.AddRange(
                new Banner
                {
                    Id          = 1,
                    Title       = "Học lập trình Web với SkillUp",
                    Description = "Khóa học từ cơ bản đến nâng cao, giảng dạy bởi các chuyên gia hàng đầu.",
                    Image       = "https://res.cloudinary.com/demo/image/upload/sample_banner1.jpg",
                    Hyperlink   = "/courses",
                    IsActive    = true
                },
                new Banner
                {
                    Id          = 2,
                    Title       = "Data Science - Xu hướng của tương lai",
                    Description = "Khám phá thế giới dữ liệu cùng các giảng viên kinh nghiệm.",
                    Image       = "https://res.cloudinary.com/demo/image/upload/sample_banner2.jpg",
                    Hyperlink   = "/courses?category=4",
                    IsActive    = true
                }
            );
            await SaveWithIdentityInsertAsync(db, "Banner");
        }

        // ── 8. VoucherTypes ─────────────────────────────────────────────────────
        if (!await db.VoucherTypes.AnyAsync())
        {
            db.VoucherTypes.AddRange(
                new VoucherType { Id = 1, Name = "Percentage", Percentage = 10, IsActive = true },
                new VoucherType { Id = 2, Name = "Percentage", Percentage = 20, IsActive = true },
                new VoucherType { Id = 3, Name = "Percentage", Percentage = 30, IsActive = true },
                new VoucherType { Id = 4, Name = "Fixed",      Percentage = 0,  IsActive = true }
            );
            await SaveWithIdentityInsertAsync(db, "VoucherType");
        }

        // ── 9. Courses ──────────────────────────────────────────────────────────
        if (!await db.Courses.AnyAsync())
        {
            var now = DateTime.UtcNow;
            db.Courses.AddRange(
                new Course
                {
                    Id              = Course1Id,
                    Title           = "HTML & CSS từ A đến Z",
                    Description     = "Khóa học toàn diện về HTML5 và CSS3 dành cho người mới bắt đầu. Bạn sẽ học cách xây dựng trang web đẹp, responsive từ đầu.",
                    Image           = "https://res.cloudinary.com/demo/image/upload/course_html_css.jpg",
                    Price           = 299000,
                    OriginalPrice   = 499000,
                    EnrollmentCount = 150,
                    Rating          = 4.7,
                    Status          = "Published",
                    IsActive        = true,
                    LecturerId      = Lecturer1Id,
                    SubCategoryId   = 1,
                    CreatedAt       = now,
                    UpdatedAt       = now
                },
                new Course
                {
                    Id              = Course2Id,
                    Title           = "ASP.NET Core Web API",
                    Description     = "Xây dựng RESTful API chuyên nghiệp với ASP.NET Core 8, Entity Framework Core và SQL Server.",
                    Image           = "https://res.cloudinary.com/demo/image/upload/course_aspnet.jpg",
                    Price           = 499000,
                    OriginalPrice   = 799000,
                    EnrollmentCount = 87,
                    Rating          = 4.5,
                    Status          = "Published",
                    IsActive        = true,
                    LecturerId      = Lecturer1Id,
                    SubCategoryId   = 2,
                    CreatedAt       = now,
                    UpdatedAt       = now
                },
                new Course
                {
                    Id              = Course3Id,
                    Title           = "Python cho Khoa học dữ liệu",
                    Description     = "Học Python ứng dụng trong phân tích dữ liệu, machine learning với pandas, numpy, scikit-learn.",
                    Image           = "https://res.cloudinary.com/demo/image/upload/course_python.jpg",
                    Price           = 399000,
                    OriginalPrice   = 699000,
                    EnrollmentCount = 212,
                    Rating          = 4.8,
                    Status          = "Published",
                    IsActive        = true,
                    LecturerId      = Lecturer2Id,
                    SubCategoryId   = 8,
                    CreatedAt       = now,
                    UpdatedAt       = now
                }
            );
            await db.SaveChangesAsync();
        }

        // ── 10. Sections ────────────────────────────────────────────────────────
        if (!await db.Sections.AnyAsync())
        {
            var now = DateTime.UtcNow;
            db.Sections.AddRange(
                new Section { Id = Section1Id, CourseId = Course1Id, Title = "Giới thiệu HTML",          Description = "Các thẻ cơ bản của HTML5",             Orders = 1, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new Section { Id = Section2Id, CourseId = Course1Id, Title = "CSS Cơ bản",               Description = "Selectors, Box model, Flexbox",        Orders = 2, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new Section { Id = Section3Id, CourseId = Course2Id, Title = "Giới thiệu ASP.NET Core",  Description = "Setup project và cấu trúc thư mục",    Orders = 1, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new Section { Id = Section4Id, CourseId = Course3Id, Title = "Python cơ bản",            Description = "Syntax, kiểu dữ liệu, vòng lặp",      Orders = 1, IsActive = true, CreatedAt = now, UpdatedAt = now }
            );
            await db.SaveChangesAsync();
        }

        // ── 11. Lessons ─────────────────────────────────────────────────────────
        if (!await db.Lessons.AnyAsync())
        {
            var now = DateTime.UtcNow;
            db.Lessons.AddRange(
                new Lesson { Id = Lesson1Id, SectionId = Section1Id, Title = "HTML là gì?",              Type = "Video", Orders = 1, IsActive = true, IsFree = true,  CreatedAt = now, UpdatedAt = now },
                new Lesson { Id = Lesson2Id, SectionId = Section1Id, Title = "Thẻ heading và paragraph", Type = "Video", Orders = 2, IsActive = true, IsFree = true,  CreatedAt = now, UpdatedAt = now },
                new Lesson { Id = Lesson3Id, SectionId = Section2Id, Title = "CSS Selectors",            Type = "Video", Orders = 1, IsActive = true, IsFree = false, CreatedAt = now, UpdatedAt = now },
                new Lesson { Id = Lesson4Id, SectionId = Section3Id, Title = "Tạo project đầu tiên",    Type = "Video", Orders = 1, IsActive = true, IsFree = true,  CreatedAt = now, UpdatedAt = now },
                new Lesson { Id = Lesson5Id, SectionId = Section4Id, Title = "Cài đặt Python",          Type = "Video", Orders = 1, IsActive = true, IsFree = true,  CreatedAt = now, UpdatedAt = now }
            );
            await db.SaveChangesAsync();
        }

        // ── 12. Carts ───────────────────────────────────────────────────────────
        if (!await db.Carts.AnyAsync())
        {
            db.Carts.AddRange(
                new Cart { Id = Cart1Id, StudentId = Student1Id },
                new Cart { Id = Cart2Id, StudentId = Student2Id },
                new Cart { Id = Cart3Id, StudentId = Student3Id }
            );
            await db.SaveChangesAsync();
        }

        // ── 13. Enrollments ─────────────────────────────────────────────────────
        if (!await db.Enrollments.AnyAsync())
        {
            var now = DateTime.UtcNow;
            db.Enrollments.AddRange(
                new Enrollment { Id = Guid.NewGuid(), StudentId = Student1Id, CourseId = Course1Id, EnrolledAt = now.AddDays(-30) },
                new Enrollment { Id = Guid.NewGuid(), StudentId = Student1Id, CourseId = Course3Id, EnrolledAt = now.AddDays(-15) },
                new Enrollment { Id = Guid.NewGuid(), StudentId = Student2Id, CourseId = Course1Id, EnrolledAt = now.AddDays(-20) },
                new Enrollment { Id = Guid.NewGuid(), StudentId = Student2Id, CourseId = Course2Id, EnrolledAt = now.AddDays(-10) },
                new Enrollment { Id = Guid.NewGuid(), StudentId = Student3Id, CourseId = Course3Id, EnrolledAt = now.AddDays(-5)  }
            );
            await db.SaveChangesAsync();
        }

        // ── 14. Ratings ─────────────────────────────────────────────────────────
        if (!await db.Ratings.AnyAsync())
        {
            var now = DateTime.UtcNow;
            db.Ratings.AddRange(
                new Rating { StudentId = Student1Id, CourseId = Course1Id, Star = 5, Contents = "Khóa học rất tốt, dễ hiểu!",              CreatedAt = now.AddDays(-25) },
                new Rating { StudentId = Student2Id, CourseId = Course1Id, Star = 4, Contents = "Nội dung đầy đủ, giảng viên nhiệt tình.", CreatedAt = now.AddDays(-18) },
                new Rating { StudentId = Student1Id, CourseId = Course3Id, Star = 5, Contents = "Tuyệt vời! Python dễ học hơn tôi nghĩ.", CreatedAt = now.AddDays(-10) }
            );
            await db.SaveChangesAsync();
        }

        // ── 15. Vouchers ────────────────────────────────────────────────────────
        if (!await db.Vouchers.AnyAsync())
        {
            var now = DateTime.UtcNow;
            db.Vouchers.AddRange(
                new Voucher
                {
                    Id          = Guid.NewGuid(),
                    CourseId    = null,        // toàn sàn
                    VoucherType = 1,
                    CouponCode  = "WELCOME10",
                    StartTime   = now,
                    EndTime     = now.AddMonths(3),
                    Price       = 0,
                    IsActive    = true
                },
                new Voucher
                {
                    Id          = Guid.NewGuid(),
                    CourseId    = Course1Id,
                    VoucherType = 2,
                    CouponCode  = "HTML20",
                    StartTime   = now,
                    EndTime     = now.AddMonths(1),
                    Price       = 0,
                    IsActive    = true
                }
            );
            await db.SaveChangesAsync();
        }
    }
}
