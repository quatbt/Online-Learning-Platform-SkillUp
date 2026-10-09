# Hướng dẫn cài đặt và chạy dự án SkillUp

## 1. Yêu cầu môi trường
- **.NET 8 SDK** (để chạy Backend)
- **Node.js (v18+)** (để chạy Frontend)
- **SQL Server** (cài trực tiếp hoặc dùng Docker)
- **Docker** (tùy chọn — nếu muốn chạy SQL Server bằng Docker)

---

## 2. Cài đặt SQL Server bằng Docker (tùy chọn)

Nếu bạn chưa cài SQL Server trên máy, có thể dùng Docker để khởi tạo nhanh.

### Bước 2.1: Khởi chạy SQL Server
Tại thư mục gốc dự án (nơi chứa file `docker-compose.yml`), chạy:
```bash
docker compose up -d
```
Lệnh này sẽ khởi tạo SQL Server 2022 với:
- **Port**: `1433`
- **User**: `sa`
- **Password**: `12345678@Abc`

### Bước 2.2: Cấu hình chuỗi kết nối cho Docker
Mở `SkillUp_BE/SkillUp/appsettings.json`, đổi `ConnectionStrings` thành:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=SkillUpDev;Uid=sa;Pwd=12345678@Abc;TrustServerCertificate=true;Encrypt=false"
}
```

### Dừng / Xóa container
```bash
docker compose down          # Dừng (giữ dữ liệu)
docker compose down -v       # Dừng và xóa dữ liệu
```

---

## 3. Cấu hình và chạy Backend (Tự động Migrate)

Dự án đã tích hợp sẵn cơ chế **Auto-Migrate** và **Auto-Seed** khi khởi động (chạy trong `Program.cs`). Bạn không cần chạy lệnh `update-database` thủ công, chỉ cần chạy ứng dụng là Database và dữ liệu mẫu sẽ tự động được tạo.

### Bước 3.1: Cấu hình chuỗi kết nối
Mở file cấu hình Backend tại:
`SkillUp_BE/SkillUp/appsettings.json`

Tìm mục `ConnectionStrings` và chỉnh sửa lại `DefaultConnection` cho phù hợp với tài khoản SQL Server của bạn (Bỏ qua bước này nếu dùng Docker ở Mục 2):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(local);Database=SkillUpDev;Uid=sa;Pwd=123;TrustServerCertificate=true;Encrypt=false"
}
```

### Bước 3.2: Build và Khởi chạy
Mở terminal và di chuyển vào thư mục dự án Backend:
```bash
cd SkillUp_BE/SkillUp
```

Chạy lệnh để khởi động server:
```bash
dotnet run
```
> Khi server khởi động, nó sẽ tự động chạy Migrate và Seed data (tài khoản mẫu, Role, Category...).

*(Nếu muốn migrate thủ công mà không chạy app, dùng lệnh: `dotnet ef database update`)*

### Thông tin tài khoản mẫu (Seed Data)
Mật khẩu chung cho tất cả tài khoản là: `12345678@Abc`

- **Admin**: `admin@skillup.vn`
- **Content Moderator**: `content.mod@skillup.vn`
- **System Moderator**: `system.mod@skillup.vn`
- **Giảng viên**: `lecturer1@skillup.vn`
- **Học viên**: `student1@gmail.com`

> **Swagger URL (BE)**: `http://localhost:5120/swagger`

---

## 4. Cấu hình và chạy Frontend

### Bước 4.1: Cài đặt thư viện
Mở một terminal mới (giữ BE vẫn chạy) và di chuyển vào thư mục Frontend:
```bash
cd SkillUp_FE
```

Chạy lệnh để tải dependencies (chỉ cần chạy lần đầu):
```bash
npm install
```

### Bước 4.2: Khởi chạy Client
Bật Frontend bằng lệnh:
```bash
npm run dev
```

> **Giao diện Client (FE)**: `http://localhost:5173`
