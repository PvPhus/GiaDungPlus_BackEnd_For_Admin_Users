CREATE DATABASE GiaDungPlusAfter
GO

USE GiaDungPlusAfter
GO

-- Bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY,
    TenNhaCungCap NVARCHAR(255),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20)
);

-- Bảng Hóa Đơn Nhập
CREATE TABLE HoaDonNhap (
    MaHoaDonNhap INT PRIMARY KEY,
	MaNhanVien INT,
    MaNhaCungCap INT,
    NgayNhap DATE,
    TongTien DECIMAL(18, 0),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap),
	FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng Chi Tiết Hóa Đơn Nhập
CREATE TABLE ChiTietHoaDonNhap (
    MaHoaDonNhap INT,
    MaSanPham INT,
    SoLuong INT,
    DonGia DECIMAL(18, 0),
    ThanhTien DECIMAL(18, 0),
    FOREIGN KEY (MaHoaDonNhap) REFERENCES HoaDonNhap(MaHoaDonNhap),
    FOREIGN KEY (MaSanPham) REFERENCES DoGiaDung(MaSanPham)
);

-- Bảng Đồ Gia Dụng
CREATE TABLE DoGiaDung (
    MaSanPham INT PRIMARY KEY,
    TenSanPham NVARCHAR(255),
    Gia DECIMAL(18, 0),
    MoTa NVARCHAR(MAX),
    HinhAnh NVARCHAR(500),
    MaLoai INT,
    FOREIGN KEY (MaLoai) REFERENCES LoaiDoGiaDung(MaLoai)
);

-- Bảng Loại Đồ Gia Dụng
CREATE TABLE LoaiDoGiaDung (
    MaLoai INT PRIMARY KEY,
    TenLoai NVARCHAR(50),
	SoLuongLoaiTon INT
);

-- Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    TenNhanVien NVARCHAR(255),
    ChucVu NVARCHAR(50),
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20)
);

-- Bảng Chi Tiết Hóa Đơn Bán
CREATE TABLE ChiTietHoaDonBan (
    MaHoaDonBan INT,
	MaSanPham INT,
    SoLuong INT,
    DonGia DECIMAL(18, 0),
    ThanhTien DECIMAL(18, 0),
    FOREIGN KEY (MaHoaDonBan) REFERENCES HoaDonBan(MaHoaDonBan),
    FOREIGN KEY (MaSanPham) REFERENCES DoGiaDung(MaSanPham)
);

-- Bảng Hóa Đơn Bán
CREATE TABLE HoaDonBan (
    MaHoaDonBan INT PRIMARY KEY,
	MaNhanVien INT,
    MaKhachHang INT,
    NgayBan DATE,  
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY,
    TenKhachHang NVARCHAR(255),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20)
);

--Bảng Slide
CREATE TABLE Slide(
	MaAnh INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TieuDe NVARCHAR(250) NULL,
	MoTa NVARCHAR(250) NULL,
	LinkAnh NVARCHAR(max) NULL,
);

-- Bảng Tài Khoản
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT PRIMARY KEY,
    TenTaiKhoan NVARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(50),
    LoaiTaiKhoan NVARCHAR(20), -- Định nghĩa loại tài khoản, có thể là 'NhanVien' hoặc 'KhachHang'
    MaNhanVien INT NULL, -- Nếu là nhân viên
    MaKhachHang INT NULL, -- Nếu là khách hàng
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

--====================================================================================================================================
------===========================================------NHẬP DỮ LIỆU CHO CÁC BẢNG-------=============================================----
--====================================================================================================================================
----INSERT VÀO BẢNG NHÀ CUNG CẤP
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
VALUES
    (1, N'Nhà cung cấp 1', N'Địa chỉ 1', '0123456789'),
    (2, N'Nhà cung cấp 2', N'Địa chỉ 2', '0987654321'),
    (3, N'Nhà cung cấp 3', N'Địa chỉ 3', '0123456789'),
    (4, N'Nhà cung cấp 4', N'Địa chỉ 4', '0987654321'),
    (5, N'Nhà cung cấp 5', N'Địa chỉ 5', '0123456789'),
    (6, N'Nhà cung cấp 6', N'Địa chỉ 6', '0987654321'),
    (7, N'Nhà cung cấp 7', N'Địa chỉ 7', '0123456789'),
    (8, N'Nhà cung cấp 8', N'Địa chỉ 8', '0987654321'),
    (9, N'Nhà cung cấp 9', N'Địa chỉ 9', '0123456789'),
    (10, N'Nhà cung cấp 10', N'Địa chỉ 10', '0987654321'),
    (11, N'Nhà cung cấp 11', N'Địa chỉ 11', '0123456789'),
    (12, N'Nhà cung cấp 12', N'Địa chỉ 12', '0987654321'),
    (13, N'Nhà cung cấp 13', N'Địa chỉ 13', '0123456789'),
    (14, N'Nhà cung cấp 14', N'Địa chỉ 14', '0987654321'),
    (15, N'Nhà cung cấp 15', N'Địa chỉ 15', '0123456789'),
    (16, N'Nhà cung cấp 16', N'Địa chỉ 16', '0987654321'),
    (17, N'Nhà cung cấp 17', N'Địa chỉ 17', '0123456789'),
    (18, N'Nhà cung cấp 18', N'Địa chỉ 18', '0987654321'),
    (19, N'Nhà cung cấp 19', N'Địa chỉ 19', '0123456789'),
    (20, N'Nhà cung cấp 20', N'Địa chỉ 20', '0987654321');
----INSERT VÀO BẢNG HÓA ĐƠN NHẬP
INSERT INTO HoaDonNhap (MaHoaDonNhap, MaNhaCungCap, NgayNhap, TongTien)
VALUES
    (1, 1, '2023-01-01', 5000000),
    (2, 2, '2023-01-02', 7000000),
    (3, 3, '2023-01-03', 10000000),
    (4, 4, '2023-01-04', 8000000),
    (5, 5, '2023-01-05', 12000000),
    (6, 6, '2023-01-06', 15000000),
    (7, 7, '2023-01-07', 9000000),
    (8, 8, '2023-01-08', 11000000),
    (9, 9, '2023-01-09', 13000000),
    (10, 10, '2023-01-10', 16000000),
    (11, 11, '2023-01-11', 18000000),
    (12, 12, '2023-01-12', 20000000),
    (13, 13, '2023-01-13', 22000000),
    (14, 14, '2023-01-14', 24000000),
    (15, 15, '2023-01-15', 26000000),
    (16, 16, '2023-01-16', 28000000),
    (17, 17, '2023-01-17', 30000000),
    (18, 18, '2023-01-18', 32000000),
    (19, 19, '2023-01-19', 34000000),
    (20, 20, '2023-01-20', 36000000);
----INSERT VÀO BẢNG CHI TIẾT HÓA ĐƠN NHẬP
INSERT INTO ChiTietHoaDonNhap (MaChiTiet, MaHoaDonNhap, MaSanPham, SoLuong, DonGia, ThanhTien)
VALUES
    (1, 1, 1, 5, 1000000, 5000000),
    (2, 2, 2, 7, 900000, 6300000),
    (3, 3, 3, 10, 1200000, 12000000),
    (4, 4, 4, 8, 1000000, 8000000),
    (5, 5, 5, 12, 1500000, 18000000),
    (6, 6, 6, 15, 2000000, 30000000),
    (7, 7, 7, 9, 800000, 7200000),
    (8, 8, 8, 11, 1100000, 12100000),
    (9, 9, 9, 13, 1300000, 16900000),
    (10, 10, 10, 16, 1600000, 25600000),
    (11, 11, 11, 18, 1800000, 32400000),
    (12, 12, 12, 20, 2000000, 40000000),
    (13, 13, 13, 22, 2200000, 48400000),
    (14, 14, 14, 24, 2400000, 57600000),
    (15, 15, 15, 26, 2600000, 67600000),
    (16, 16, 16, 28, 2800000, 78400000),
    (17, 17, 17, 30, 3000000, 90000000),
    (18, 18, 18, 32, 3200000, 102400000),
    (19, 19, 19, 34, 3400000, 115600000),
    (20, 20, 20, 36, 3600000, 129600000);
----INSERT VÀO BẢNG NHÂN VIÊN
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, ChucVu, NgaySinh, DiaChi, SoDienThoai)
VALUES
    (1, N'Nguyễn Văn A', N'Quản lý', '1990-01-01', N'Địa chỉ A', '0123456789'),
    (2, N'Trần Thị B', N'Nhân viên bán hàng', '1992-05-15', N'Địa chỉ B', '0987654321'),
    (3, N'Lê Văn C', N'Nhân viên kho', '1988-08-20', N'Địa chỉ C', '0123456789'),
    (4, N'Phạm Thị D', N'Nhân viên bán hàng', '1995-03-10', N'Địa chỉ D', '0987654321'),
    (5, N'Huỳnh Văn E', N'Kế toán', '1993-12-05', N'Địa chỉ E', '0123456789'),
    (6, N'Võ Thị F', N'Nhân viên bảo vệ', '1994-07-18', N'Địa chỉ F', '0987654321'),
    (7, N'Mai Văn G', N'Nhân viên bán hàng', '1998-09-22', N'Địa chỉ G', '0123456789'),
    (8, N'Đặng Thị H', N'Kế toán', '1996-04-30', N'Địa chỉ H', '0987654321'),
    (9, N'Nguyễn Văn I', N'Nhân viên kho', '1991-11-25', N'Địa chỉ I', '0123456789'),
    (10, N'Phan Thị K', N'Nhân viên bảo vệ', '1999-08-12', N'Địa chỉ K', '0987654321'),
    (11, N'Bùi Văn L', N'Nhân viên bán hàng', '1997-06-05', N'Địa chỉ L', '0123456789'),
    (12, N'Hoàng Thị M', N'Kế toán', '1994-03-28', N'Địa chỉ M', '0987654321'),
    (13, N'Trương Văn N', N'Nhân viên bảo vệ', '1993-02-14', N'Địa chỉ N', '0123456789'),
    (14, N'Lâm Thị P', N'Nhân viên kho', '1989-10-17', N'Địa chỉ P', '0987654321'),
    (15, N'Nguyễn Văn Q', N'Nhân viên bán hàng', '1996-09-29', N'Địa chỉ Q', '0123456789'),
    (16, N'Hồ Thị R', N'Nhân viên bảo vệ', '1992-08-02', N'Địa chỉ R', '0987654321'),
    (17, N'Ma Văn S', N'Kế toán', '1998-07-15', N'Địa chỉ S', '0123456789'),
    (18, N'Vương Thị T', N'Nhân viên kho', '1995-06-18', N'Địa chỉ T', '0987654321'),
    (19, N'Lê Văn U', N'Nhân viên bán hàng', '1990-05-01', N'Địa chỉ U', '0123456789'),
    (20, N'Đỗ Thị V', N'Nhân viên bảo vệ', '1997-04-14', N'Địa chỉ V', '0987654321');
----INSERT VÀO BẢNG ĐỒ GIA DỤNG
INSERT INTO DoGiaDung (MaSanPham, TenSanPham, Gia, MoTa, HinhAnh, MaLoai)
VALUES
    (1, 'Đèn LED thông minh Philips Hue', 800000, 'Đèn LED thông minh có thể điều chỉnh màu sắc', '/images/den-philips-hue.jpg', 1),
    (2, 'Tủ lạnh LG Inverter', 10000000, 'Tủ lạnh tiết kiệm năng lượng', '/images/tu-lanh-lg.jpg', 2),
    (3, 'Máy lọc không khí Xiaomi', 2000000, 'Máy lọc không khí thông minh', '/images/may-loc-khong-khi-xiaomi.jpg', 3),
    (4, 'Bếp từ', 15000000, 'Bếp từ siêu tiết kiệm điện năng', '', 4),
    (5, 'Máy hút bụi Series 7', 8000000, 'Máy hút bụi thông minh của Apple', '', 5),
    (6, 'Lò vi sóng', 12000000, 'Lò vi sóng công nghệ QLED với độ phân giải 4K', '', 6),
    (7, 'Máy lọc nước', 25000000, 'Máy lọc nước khoáng thanh mát', '', 7),
    (8, 'Bếp điện từ', 5000000, 'Bếp điện từ cao cấp', '', 8),
    (9, 'Robot hút bụi', 3500000, 'Robot hút bụi thông minh', '', 9),
    (10, 'Máy pha cà phê', 12000000, 'Máy pha cà phê tự động', '', 10),
    (11, 'Quạt thông minh', 1500000, 'Quạt thông minh có thể điều khiển từ xa', '', 11),
    (12, 'Máy giặt', 7000000, 'Máy giặt công nghệ inverter', '', 12),
    (13, 'Điều hòa thông minh', 12000000, 'Điều hòa thông minh có điều khiển bằng giọng nói', '', 13),
    (14, 'Camera an ninh', 2500000, 'Camera an ninh không dây', '', 14),
    (15, 'Máy sưởi', 800000, 'Máy sưởi tiết kiệm năng lượng', '', 15),
    (16, 'Ổ cắm thông minh', 500000, 'Ổ cắm thông minh có thể điều khiển từ xa', '', 16),
    (17, 'Thiết bị điều khiển từ xa', 200000, 'Thiết bị điều khiển từ xa thông minh', '', 17),
    (18, 'Máy là', 1500000, 'Máy là công nghệ inverter', '', 18),
    (19, 'Dụng cụ nhà bếp', 300000, 'Bộ dụng cụ nhà bếp chất lượng cao', '', 19),
    (20, 'Phụ kiện điện tử gia dụng', 100000, 'Phụ kiện đa dạng cho thiết bị điện tử', '', 20);
----INSERT VÀO BẢNG LOẠI ĐỒ GIA DỤNG
INSERT INTO LoaiDoGiaDung (MaLoai, TenLoai)
VALUES
    (1, 'Đèn thông minh'),
    (2, 'Tủ lạnh'),
    (3, 'Máy lọc không khí'),
    (4, 'Bếp từ'),
    (5, 'Máy hút bụi'),
    (6, 'Lò vi sóng'),
    (7, 'Máy lọc nước'),
    (8, 'Bếp điện từ'),
    (9, 'Robot hút bụi'),
    (10, 'Máy pha cà phê'),
    (11, 'Quạt thông minh'),
    (12, 'Máy giặt'),
    (13, 'Điều hòa thông minh'),
    (14, 'Camera an ninh'),
    (15, 'Máy sưởi'),
    (16, 'Ổ cắm thông minh'),
    (17, 'Thiết bị điều khiển từ xa'),
    (18, 'Máy là'),
    (19, 'Dụng cụ nhà bếp'),
    (20, 'Phụ kiện điện tử gia dụng');
----INSERT VÀO BẢNG HÓA ĐƠN BÁN
INSERT INTO HoaDonBan (MaHoaDonBan, MaNhanVien, MaKhachHang, NgayBan)
VALUES
    (1, 1,1, '2023-01-01'),
    (2, 2,2, '2023-01-02'),
    (3, 3,3, '2023-01-03'),
    (4, 4,4, '2023-01-04'),
    (5, 5,5, '2023-01-05'),
    (6, 6,6, '2023-01-06'),
    (7, 7,7, '2023-01-07'),
    (8, 8,8, '2023-01-08'),
    (9, 9,9, '2023-01-09'),
    (10, 10,10, '2023-01-10'),
    (11, 11,11, '2023-01-11'),
    (12, 12,12, '2023-01-12'),
    (13, 13,13, '2023-01-13'),
    (14, 14,14, '2023-01-14'),
    (15, 15,15, '2023-01-15'),
    (16, 16,16, '2023-01-16'),
    (17, 17,17, '2023-01-17'),
    (18, 18,18, '2023-01-18'),
    (19, 19,19, '2023-01-19'),
    (20, 20,20, '2023-01-20');
----INSERT VÀO BẢNG CHI TIẾT HÓA ĐƠN BÁN
INSERT INTO ChiTietHoaDonBan (MaHoaDonBan, MaSanPham, SoLuong, DonGia, ThanhTien)
VALUES
    (1, 1, 2, 250000, 500000),
    (2, 2, 3, 200000, 600000),
    (3, 3, 1, 1000000, 1000000),
    (4, 4, 4, 150000, 600000),
    (5, 5, 2, 400000, 800000),
    (6, 6, 1, 600000, 600000),
    (7, 7, 3, 300000, 900000),
    (8, 8, 2, 500000, 1000000),
    (9, 9, 1, 950000, 950000),
    (10, 10, 2, 250000, 500000),
    (11, 11, 4, 150000, 600000),
    (12, 12, 1, 1000000, 1000000),
    (13, 13, 3, 200000, 600000),
    (14, 14, 2, 400000, 800000),
    (15, 15, 1, 600000, 600000),
    (16, 16, 2, 500000, 1000000),
    (17, 17, 1, 950000, 950000),
    (18, 18, 2, 250000, 500000),
    (19, 19, 3, 200000, 600000),
    (20, 20, 1, 1000000, 1000000);
----INSERT VÀO BẢNG KHÁCH HÀNG
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, SoDienThoai)
VALUES
    (1, N'Nguyễn Văn Khách 1', N'Địa chỉ 1', '0123456789'),
    (2, N'Trần Thị Khách 2', N'Địa chỉ 2', '0987654321'),
    (3, N'Lê Văn Khách 3', N'Địa chỉ 3', '0123456789'),
    (4, N'Phạm Thị Khách 4', N'Địa chỉ 4', '0987654321'),
    (5, N'Huỳnh Văn Khách 5', N'Địa chỉ 5', '0123456789'),
    (6, N'Võ Thị Khách 6', N'Địa chỉ 6', '0987654321'),
    (7, N'Mai Văn Khách 7', N'Địa chỉ 7', '0123456789'),
    (8, N'Đặng Thị Khách 8', N'Địa chỉ 8', '0987654321'),
    (9, N'Nguyễn Văn Khách 9', N'Địa chỉ 9', '0123456789'),
    (10, N'Phan Thị Khách 10', N'Địa chỉ 10', '0987654321'),
    (11, N'Bùi Văn Khách 11', N'Địa chỉ 11', '0123456789'),
    (12, N'Hoàng Thị Khách 12', N'Địa chỉ 12', '0987654321'),
    (13, N'Trương Văn Khách 13', N'Địa chỉ 13', '0123456789'),
    (14, N'Lâm Thị Khách 14', N'Địa chỉ 14', '0987654321'),
    (15, N'Nguyễn Văn Khách 15', N'Địa chỉ 15', '0123456789'),
    (16, N'Hồ Thị Khách 16', N'Địa chỉ 16', '0987654321'),
    (17, N'Ma Văn Khách 17', N'Địa chỉ 17', '0123456789'),
    (18, N'Vương Thị Khách 18', N'Địa chỉ 18', '0987654321'),
    (19, N'Lê Văn Khách 19', N'Địa chỉ 19', '0123456789'),
    (20, N'Đỗ Thị Khách 20', N'Địa chỉ 20', '0987654321');
----INSERT VÀO BẢNG SLIDE
INSERT INTO Slide (TieuDe, MoTa, LinkAnh)
VALUES
    ('Slide 1', 'Mô tả cho Slide 1', '/images/slide1.jpg'),
    ('Slide 2', 'Mô tả cho Slide 2', '/images/slide2.jpg'),
    ('Slide 3', 'Mô tả cho Slide 3', '/images/slide3.jpg'),
    ('Slide 4', 'Mô tả cho Slide 4', '/images/slide4.jpg'),
    ('Slide 5', 'Mô tả cho Slide 5', '/images/slide5.jpg'),
    ('Slide 6', 'Mô tả cho Slide 6', '/images/slide6.jpg'),
    ('Slide 7', 'Mô tả cho Slide 7', '/images/slide7.jpg'),
    ('Slide 8', 'Mô tả cho Slide 8', '/images/slide8.jpg'),
    ('Slide 9', 'Mô tả cho Slide 9', '/images/slide9.jpg'),
    ('Slide 10', 'Mô tả cho Slide 10', '/images/slide10.jpg');
----INSERT VÀO BẢNG TÀI KHOẢN
INSERT INTO TaiKhoan (MaTaiKhoan, TenTaiKhoan, MatKhau, LoaiTaiKhoan, MaNhanVien, MaKhachHang)
VALUES
    (1,'user1', 'password1', 'KhachHang', NULL, 1),
    (2,'user2', 'password2', 'KhachHang', NULL, 2),
    (3,'user3', 'password3', 'KhachHang', NULL, 3),
    (4,'employee1', 'password4', 'NhanVien', 1, NULL),
    (5,'employee2', 'password5', 'NhanVien', 2, NULL);
--=========================================================================================================================================
--=========================================================STORE PROCEDURES=============================================================---
--=========================================================================================================================================


--=====================================================Store Procedure-Sản Phẩm-Đồ Gia Dụng=============================================--
--SẢN PHẨM - SEARCH
CREATE PROCEDURE [dbo].[sp_sanpham_search]
    @page_index INT,
    @page_size INT,
    @ten_sanpham NVARCHAR(100) 
AS
BEGIN
    DECLARE @RecordCount BIGINT;

    IF (@page_size <> 0)
    BEGIN
        SET NOCOUNT ON;

        SELECT
            (ROW_NUMBER() OVER (ORDER BY TenSanPham ASC)) AS RowNumber,
            s.MaSanPham,
            s.TenSanPham,
            s.Gia,
            s.MoTa,
            s.HinhAnh,
			s.MaLoai
        INTO #Results1
        FROM DoGiaDung AS s
        WHERE
            (@ten_sanpham = '' OR s.TenSanPham LIKE N'%' + @ten_sanpham + '%');
        SELECT @RecordCount = COUNT(*) FROM #Results1;

        SELECT *,
               @RecordCount AS RecordCount
        FROM #Results1
        WHERE RowNumber BETWEEN (@page_index - 1) * @page_size + 1 AND ((@page_index - 1) * @page_size + 1) + @page_size - 1
           OR @page_index = -1;
    END;
    ELSE
    BEGIN
        SET NOCOUNT ON;

        SELECT
            (ROW_NUMBER() OVER (ORDER BY TenSanPham ASC)) AS RowNumber,
            s.MaSanPham,
            s.TenSanPham,
            s.Gia,
            s.MoTa,
            s.HinhAnh,
			s.MaLoai
        INTO #Results2
        FROM DoGiaDung AS s
        WHERE
            (@ten_sanpham = '' OR s.TenSanPham LIKE N'%' + @ten_sanpham + '%');   
        SELECT @RecordCount = COUNT(*) FROM #Results2;

        SELECT *,
               @RecordCount AS RecordCount
        FROM #Results2;
    END;
END;

--SẢN PHẨM - CREATE
CREATE PROCEDURE [dbo].[sp_san_pham_create](
@MaSanPham INT,
@TenSanPham nvarchar(100),
@Gia decimal(18, 0),
@MoTa nvarchar(MAX),
@HinhAnh varchar(500)
)
AS
    BEGIN
       insert into DoGiaDung(MaSanPham,TenSanPham,Gia,MoTa,HinhAnh)
	   values(@MaSanPham,@TenSanPham,@Gia,@MoTa,@HinhAnh);
    END;

--Sản Phẩm - Update.
CREATE PROCEDURE [dbo].[sp_san_pham_update](
    @MaSanPham INT,
    @TenSanPham NVARCHAR(100),
    @Gia DECIMAL(18, 0),
    @MoTa NVARCHAR(MAX),
    @HinhAnh VARCHAR(500),
	@MaLoai INT
)
AS
BEGIN   
    UPDATE DoGiaDung
    SET TenSanPham = ISNULL(@TenSanPham, TenSanPham),
        Gia = ISNULL(@Gia, Gia),
        MoTa = ISNULL(@MoTa, MoTa),
        HinhAnh = ISNULL(@HinhAnh, HinhAnh),
		MaLoai = ISNULL(@MaLoai, MaLoai)
    WHERE MaSanPham = @MaSanPham;
END;

--SẢN PHẨM - DELETE
CREATE PROCEDURE [dbo].[sp_san_pham_delete](
    @MaSanPham int
)
AS
BEGIN
    DELETE FROM DoGiaDung WHERE MaSanPham = @MaSanPham;
END;

--SẢN PHẨM - GET BY ID--
CREATE PROCEDURE [dbo].[sp_sanpham_get_by_id](@MaSanPham int)
AS
    BEGIN
        SELECT s.*, 
        (
            SELECT top 6 sp.*
            FROM DoGiaDung AS sp
            WHERE sp.TenSanPham = s.TenSanPham FOR JSON PATH
        ) AS list_json_sanphamlienquan
        FROM DoGiaDung AS s
        WHERE  s.MaSanPham = @MaSanPham;
    END;

--===================================================================================================================================
--===================================================Store Procedures-Hóa Đơn Nhập===================================================
--HÓA ĐƠN NHẬP - GET BY ID
CREATE PROCEDURE [dbo].[sp_hoadonnhap_get_by_id](@MaHoaDonNhap int)
AS
    BEGIN
        SELECT h.*, 
        (
            SELECT c.*
            FROM ChiTietHoaDonNhap AS c
            WHERE h.MaHoaDonNhap = c.MaHoaDonNhap FOR JSON PATH
        ) AS list_json_chitiethoadonnhap
        FROM HoaDonNhap AS h
        WHERE  h.MaHoaDonNhap = @MaHoaDonNhap;
    END;
--HÓA ĐƠN NHẬP - CREATE
CREATE PROCEDURE [dbo].[sp_hoadonnhap_create]
(
    @MaNhanVien INT, 
    @MaNhaCungCap INT,
    @NgayNhap DATE,
    @TongTien DECIMAL(18,0),
    @list_json_chitiethoadonnhap NVARCHAR(MAX)
)
AS
BEGIN
    DECLARE @MaHoaDonNhap INT;

    -- Thêm hóa đơn nhập
    INSERT INTO HoaDonNhap
    (MaNhanVien, MaNhaCungCap, NgayNhap, TongTien)
    VALUES
    (@MaNhanVien, @MaNhaCungCap, @NgayNhap, @TongTien);

    -- Lấy mã hóa đơn nhập vừa thêm
    SET @MaHoaDonNhap = SCOPE_IDENTITY();

    -- Thêm chi tiết hóa đơn nhập từ dữ liệu JSON
    IF (@list_json_chitiethoadonnhap IS NOT NULL)
    BEGIN
        INSERT INTO ChiTietHoaDonNhap
        (MaHoaDonNhap, MaSanPham, SoLuong, DonGia, ThanhTien)
        SELECT 
            @MaHoaDonNhap, 
            JSON_VALUE(p.value, '$.maSanPham'), 
            JSON_VALUE(p.value, '$.soLuong'), 
            JSON_VALUE(p.value, '$.donGia'), 
            JSON_VALUE(p.value, '$.thanhTien')    
        FROM OPENJSON(@list_json_chitiethoadonnhap) AS p;
    END;

    SELECT 'Hóa đơn nhập đã được tạo thành công.';
END;


--HÓA ĐƠN NHẬP - Update.
CREATE PROCEDURE [dbo].[sp_hoadon_nhap_update]
(
    @MaHoaDonNhap INT, 
    @MaNhanVien INT, 
    @MaNhaCungCap INT, 
    @NgayNhap DATE,
	@TongTien DECIMAL(18,0),
    @list_json_chitiethoadonnhap NVARCHAR(MAX)
)
AS
BEGIN
    UPDATE HoaDonNhap
    SET
        MaNhanVien = @MaNhanVien,
        MaNhaCungCap = @MaNhaCungCap,
        NgayNhap = @NgayNhap,
		TongTien = @TongTien
    WHERE MaHoaDonNhap = @MaHoaDonNhap;

    IF (@list_json_chitiethoadonnhap IS NOT NULL) 
    BEGIN
        -- Tạo bảng tạm thời để chứa dữ liệu JSON
        CREATE TABLE #Results
        (           
			maChiTietHoaDonNhap INT,
            maHoaDonNhap INT,
            maSanPham INT,
            soLuong INT,
			donGia DECIMAL(18, 0),
            tongGia DECIMAL(18, 0),
            status INT
        );

        -- Insert dữ liệu từ JSON vào bảng tạm thời
        INSERT INTO #Results
        (
            maHoaDonNhap,
            maSanPham,
            soLuong,
			donGia,
            tongGia,
            status
        )
        SELECT
            JSON_VALUE(p.value, '$.maChiTietHoaDonNhap'),
            JSON_VALUE(p.value, '$.maHoaDonNhap'),
            JSON_VALUE(p.value, '$.maSanPham'),
            JSON_VALUE(p.value, '$.soLuong'),
            JSON_VALUE(p.value, '$.tongGia'),
            JSON_VALUE(p.value, '$.status')
        FROM OPENJSON(@list_json_chitiethoadonnhap) AS p;

        -- Thêm dữ liệu mới với status = 1
        INSERT INTO ChiTietHoaDonNhap
        (
            MaHoaDonNhap,
            MaSanPham,
            SoLuong,
            DonGia,
            ThanhTien
        )
        SELECT
            @MaHoaDonNhap,
            maSanPham,
            soLuong,
            tongGia,
            soLuong * tongGia
        FROM #Results
        WHERE status = 1;

        -- Cập nhật dữ liệu với status = 2
        UPDATE ChiTietHoaDonNhap
        SET
            SoLuong = r.soLuong,
            DonGia = r.tongGia,
            ThanhTien = r.soLuong * r.tongGia
        FROM #Results r
        WHERE ChiTietHoaDonNhap.MaHoaDonNhap = @MaHoaDonNhap
            AND ChiTietHoaDonNhap.MaSanPham = r.maSanPham
            AND r.status = 2;

        -- Xóa dữ liệu với status = 3
        DELETE FROM ChiTietHoaDonNhap
        WHERE EXISTS (
            SELECT 1
            FROM #Results r
            WHERE r.maChiTietHoaDonNhap = ChiTietHoaDonNhap.MaHoaDonNhap
                AND r.status = 3
        );

        -- Xóa bảng tạm thời
        DROP TABLE #Results;
    END;

    SELECT 'Cập nhật hóa đơn nhập thành công.';
END;
--HÓA ĐƠN NHẬP-DELETE
CREATE PROCEDURE [dbo].[sp_hoadon_nhap_xoa]
(
    @MaHoaDonNhap INT
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Xóa chi tiết hóa đơn nhập
    DELETE FROM ChiTietHoaDonNhap
    WHERE MaHoaDonNhap = @MaHoaDonNhap;

    -- Xóa hóa đơn nhập
    DELETE FROM HoaDonNhap
    WHERE MaHoaDonNhap = @MaHoaDonNhap;

    SELECT 'Xóa hóa đơn nhập thành công.' AS Result;
END;


--=====================================================Store Procedures-Hóa Đơn Bán=====================================--
--HÓA ĐƠN BÁN - GET BY ID
CREATE PROCEDURE [dbo].[sp_hoadon_ban_get_by_id](@MaHoaDonBan int)
AS
    BEGIN
        SELECT h.*, 
        (
            SELECT c.*
            FROM ChiTietHoaDonBan AS c
            WHERE h.MaHoaDonBan = c.MaHoaDonBan FOR JSON PATH
        ) AS list_json_chitiethoadonban
        FROM HoaDonBan AS h
        WHERE  h.MaHoaDonBan = @MaHoaDonBan;
    END;
--HÓA ĐƠN BÁN - CREATE
CREATE PROCEDURE [dbo].[sp_hoadon_ban_create]
(
    @MaNhanVien INT, 
    @MaKhachHang INT,
    @NgayBan DATE,
    @list_json_chitiethoadonban NVARCHAR(MAX)
)
AS
BEGIN
    DECLARE @MaHoaDonBan INT;

    -- Thêm hóa đơn nhập
    INSERT INTO HoaDonBan
    (MaNhanVien, MaKhachHang, NgayBan)
    VALUES
    (@MaNhanVien, @MaKhachHang, @NgayBan);

    -- Lấy mã hóa đơn nhập vừa thêm
    SET @MaHoaDonBan = SCOPE_IDENTITY();

    -- Thêm chi tiết hóa đơn nhập từ dữ liệu JSON
    IF (@list_json_chitiethoadonban IS NOT NULL)
    BEGIN
        INSERT INTO ChiTietHoaDonBan
        (MaHoaDonBan, MaSanPham, SoLuong, DonGia, ThanhTien)
        SELECT 
            @MaHoaDonBan, 
            JSON_VALUE(p.value, '$.maSanPham'), 
            JSON_VALUE(p.value, '$.soLuong'), 
            JSON_VALUE(p.value, '$.donGia'), 
            JSON_VALUE(p.value, '$.thanhTien')    
        FROM OPENJSON(@list_json_chitiethoadonban) AS p;
    END;

    SELECT 'Hóa đơn bán đã được tạo thành công.';
END;

--HÓA ĐƠN BÁN- Update.
CREATE PROCEDURE [dbo].[sp_hoadon_ban_update]
(
    @MaHoaDonBan INT, 
    @MaNhanVien INT, 
    @MaKhachHang INT, 
    @NgayBan DATE,
    @list_json_chitiethoadonban NVARCHAR(MAX)
)
AS
BEGIN
    UPDATE HoaDonban
    SET
        MaNhanVien = @MaNhanVien,
        MaKhachHang = @MaKhachHang,
        NgayBan = @NgayBan		
    WHERE MaHoaDonBan = @MaHoaDonBan;

    IF (@list_json_chitiethoadonban IS NOT NULL) 
    BEGIN
        -- Tạo bảng tạm thời để chứa dữ liệu JSON
        CREATE TABLE #Results2
        (           
			maChiTietHoaDonBan INT,
            maHoaDonBan INT,
            maSanPham INT,
            soLuong INT,
			donGia DECIMAL(18, 0),
            thanhTien DECIMAL(18, 0),
            status INT
        );

        -- Insert dữ liệu từ JSON vào bảng tạm thời
        INSERT INTO #Results2
        (
            maHoaDonBan,
            maSanPham,
            soLuong,
			donGia,
            thanhTien,
            status
        )
        SELECT
            JSON_VALUE(p.value, '$.maChiTietHoaDonBan'),
            JSON_VALUE(p.value, '$.maHoaDonBan'),
            JSON_VALUE(p.value, '$.maSanPham'),
            JSON_VALUE(p.value, '$.soLuong'),
            JSON_VALUE(p.value, '$.thanhTien'),
            JSON_VALUE(p.value, '$.status')
        FROM OPENJSON(@list_json_chitiethoadonban) AS p;

        -- Thêm dữ liệu mới với status = 1
        INSERT INTO ChiTietHoaDonNhap
        (
            MaHoaDonNhap,
            MaSanPham,
            SoLuong,
            DonGia,
            ThanhTien
        )
        SELECT
            @MaHoaDonBan,
            maSanPham,
            soLuong,
            thanhTien,
            soLuong * thanhTien
        FROM #Results2
        WHERE status = 1;

        -- Cập nhật dữ liệu với status = 2
        UPDATE ChiTietHoaDonBan
        SET
            SoLuong = r.soLuong,
            DonGia = r.thanhTien,
            ThanhTien = r.soLuong * r.thanhTien
        FROM #Results2 r
        WHERE ChiTietHoaDonBan.MaHoaDonBan = @MaHoaDonBan
            AND ChiTietHoaDonBan.MaSanPham = r.maSanPham
            AND r.status = 2;

        -- Xóa dữ liệu với status = 3
        DELETE FROM ChiTietHoaDonBan
        WHERE EXISTS (
            SELECT 1
            FROM #Results2 r
            WHERE r.maChiTietHoaDonBan = ChiTietHoaDonBan.MaHoaDonBan
                AND r.status = 3
        );

        -- Xóa bảng tạm thời
        DROP TABLE #Results2;
    END;

    SELECT 'Cập nhật hóa đơn bán thành công.';
END;
--HÓA ĐƠN BÁN - DELETE
CREATE PROCEDURE [dbo].[sp_hoadon_ban_xoa]
(
    @MaHoaDonBan INT
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Xóa chi tiết hóa đơn nhập
    DELETE FROM ChiTietHoaDonBan
    WHERE MaHoaDonBan = @MaHoaDonBan;

    -- Xóa hóa đơn nhập
    DELETE FROM HoaDonBan
    WHERE MaHoaDonBan = @MaHoaDonBan;

    SELECT 'Xóa hóa đơn bán thành công.' AS Result;
END;