using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Hyperlink = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC07F91DC404", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForumCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News__3214EC075ED16F6C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActionCode = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoucherType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VoucherT__3214EC078956618C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NewsImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NewsImag__3214EC071C3D9ECD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewImage_News",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Dob = table.Column<DateOnly>(type: "date", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false, defaultValue: "Inactive"),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__3214EC07D8410D8A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    Licensed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePermission_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BankNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReceiverName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturer_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LecturerApplication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CV = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Degree = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, defaultValue: "Pending"),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lecturer__3214EC0787742B21", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerApplication_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notify",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false, defaultValue: "Unread"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Hyperlink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notify__3214EC07A2886C76", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notify_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Otp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtpLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OtpExpiry = table.Column<DateTime>(type: "datetime", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Otp_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForumCategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false, defaultValue: "Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Post__3214EC077CA146E3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_ForumCategory",
                        column: x => x.ForumCategoryId,
                        principalTable: "ForumCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpiresUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    RevokedUtc = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketCode = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ticket__3214EC079B9F1268", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__3214EC0741DE4ECA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnrollmentCount = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, defaultValue: "Draft"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__3214EC071FD93751", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Lecturer",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_SubCategory",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comment__3214EC07A957FFD4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPost_Post",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Comment",
                        column: x => x.ParentCommentId,
                        principalTable: "CommentPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PostImag__3214EC0702A0AA6B", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImage_Post",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportPost_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportPost_Post",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__3214EC074B4E8416", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrolledAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CompletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__3214EC07FDBFD8B1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollment_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Star = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rating__3214EC071DA0D38B", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportCourse_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportCourse_Student1",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Orders = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Section__3214EC071C20F655", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    LecturerIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Transaction",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    CouponCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voucher__3214EC078E8D67B6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voucher_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voucher_VoucherType",
                        column: x => x.VoucherType,
                        principalTable: "VoucherType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentReportPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReport_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentReport_Comment",
                        column: x => x.CommentPostId,
                        principalTable: "CommentPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikeCommentPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_Comment",
                        column: x => x.CommentPostId,
                        principalTable: "CommentPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CartItem__3214EC07A0F4414C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Orders = table.Column<double>(type: "float", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lecture__3214EC07B6B95360", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Section",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionBank_Lecturer",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionBank_Section",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PassPercent = table.Column<int>(type: "int", nullable: true),
                    Timer = table.Column<int>(type: "int", nullable: true),
                    Orders = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quiz__3214EC078F61D3A4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_Section",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtitleText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSubtitleConfirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asset__3214EC0705A5B429", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_Lecture",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLesson_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentLesson_CommentLesson",
                        column: x => x.ParentCommentId,
                        principalTable: "CommentLesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentLesson_Lesson",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnswerBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerBank_QuestionBank",
                        column: x => x.QuestionBankId,
                        principalTable: "QuestionBank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionQuiz",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Orders = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionQuiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_QuestionBank",
                        column: x => x.QuestionBankId,
                        principalTable: "QuestionBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_Quiz",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizSubmission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EndedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuizSubm__3214EC078A565234", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizSubmission_Quiz",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuizSubmission_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentProgress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true),
                    LastViewedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProgress_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentProgress_Lesson",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentProgress_Quiz",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentProgress_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentReportLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReportLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReportLesson_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentReportLesson_CommentLesson",
                        column: x => x.CommentLessonId,
                        principalTable: "CommentLesson",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikeCommentLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeLesson_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LikeLesson_CommentLesson",
                        column: x => x.CommentLessonId,
                        principalTable: "CommentLesson",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswerSubmission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SubmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuizAnsw__3214EC078B53E256", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAnswerSubmission_QuestionBank",
                        column: x => x.QuestionBankId,
                        principalTable: "QuestionBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuizAnswerSubmission_QuizSubmission",
                        column: x => x.SubmissionId,
                        principalTable: "QuizSubmission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentSelectedAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizAnswerSubmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSelectedAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSelectedAnswers_AnswerBank",
                        column: x => x.AnswerBankId,
                        principalTable: "AnswerBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentSelectedAnswers_QuizAnswerSubmission",
                        column: x => x.QuizAnswerSubmissionId,
                        principalTable: "QuizAnswerSubmission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UQ__Account__A9D10534D8050F3B",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerBank_QuestionBankId",
                table: "AnswerBank",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_LessonId",
                table: "Asset",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "UQ__Cart__32C52B988A28B833",
                table: "Cart",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CourseId",
                table: "CartItems",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLesson_AccountId",
                table: "CommentLesson",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLesson_LessonId",
                table: "CommentLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLesson_ParentCommentId",
                table: "CommentLesson",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_AccountId",
                table: "CommentPost",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_ParentCommentId",
                table: "CommentPost",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_PostId",
                table: "CommentPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReportLesson_AccountId",
                table: "CommentReportLesson",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReportLesson_CommentLessonId",
                table: "CommentReportLesson",
                column: "CommentLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReportPost_AccountId",
                table: "CommentReportPost",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReportPost_CommentPostId",
                table: "CommentReportPost",
                column: "CommentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LecturerId",
                table: "Course",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubCategoryId",
                table: "Course",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "UQ__Enrollme__5E57FC822812F644",
                table: "Enrollment",
                columns: new[] { "StudentId", "CourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_AccountId",
                table: "Lecturer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerApplication_AccountId",
                table: "LecturerApplication",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SectionId",
                table: "Lesson",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCommentLesson_AccountId",
                table: "LikeCommentLesson",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCommentLesson_CommentLessonId",
                table: "LikeCommentLesson",
                column: "CommentLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCommentPost_AccountId",
                table: "LikeCommentPost",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCommentPost_CommentPostId",
                table: "LikeCommentPost",
                column: "CommentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsImage_NewsId",
                table: "NewsImage",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Notify_AccountId",
                table: "Notify",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Otp_AccountId",
                table: "Otp",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AccountId",
                table: "Post",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ForumCategoryId",
                table: "Post",
                column: "ForumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostImage_PostId",
                table: "PostImage",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBank_LecturerId",
                table: "QuestionBank",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBank_SectionId",
                table: "QuestionBank",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuiz_QuestionBankId",
                table: "QuestionQuiz",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuiz_QuizId",
                table: "QuestionQuiz",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_SectionId",
                table: "Quiz",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswerSubmission_QuestionBankId",
                table: "QuizAnswerSubmission",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswerSubmission_SubmissionId",
                table: "QuizAnswerSubmission",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_QuizId",
                table: "QuizSubmission",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_StudentId",
                table: "QuizSubmission",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CourseId",
                table: "Rating",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_StudentId",
                table: "Rating",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AccountId",
                table: "RefreshTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCourse_CourseId",
                table: "ReportCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCourse_StudentId",
                table: "ReportCourse",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPost_AccountId",
                table: "ReportPost",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPost_PostId",
                table: "ReportPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseId",
                table: "Section",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AccountId",
                table: "Student",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_CourseId",
                table: "StudentProgress",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_LessonId",
                table: "StudentProgress",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_QuizId",
                table: "StudentProgress",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_StudentId",
                table: "StudentProgress",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSelectedAnswers_AnswerBankId",
                table: "StudentSelectedAnswers",
                column: "AnswerBankId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSelectedAnswers_QuizAnswerSubmissionId",
                table: "StudentSelectedAnswers",
                column: "QuizAnswerSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AccountId",
                table: "Ticket",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_CourseId",
                table: "TransactionDetail",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_TransactionId",
                table: "TransactionDetail",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_CourseId",
                table: "Voucher",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VoucherType",
                table: "Voucher",
                column: "VoucherType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CommentReportLesson");

            migrationBuilder.DropTable(
                name: "CommentReportPost");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "LecturerApplication");

            migrationBuilder.DropTable(
                name: "LikeCommentLesson");

            migrationBuilder.DropTable(
                name: "LikeCommentPost");

            migrationBuilder.DropTable(
                name: "NewsImage");

            migrationBuilder.DropTable(
                name: "Notify");

            migrationBuilder.DropTable(
                name: "Otp");

            migrationBuilder.DropTable(
                name: "PostImage");

            migrationBuilder.DropTable(
                name: "QuestionQuiz");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ReportCourse");

            migrationBuilder.DropTable(
                name: "ReportPost");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "StudentProgress");

            migrationBuilder.DropTable(
                name: "StudentSelectedAnswers");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TransactionDetail");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "CommentLesson");

            migrationBuilder.DropTable(
                name: "CommentPost");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "AnswerBank");

            migrationBuilder.DropTable(
                name: "QuizAnswerSubmission");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "VoucherType");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.DropTable(
                name: "QuizSubmission");

            migrationBuilder.DropTable(
                name: "ForumCategory");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
