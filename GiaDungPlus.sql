USE [GiaDungPlus]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 02/12/2023 10:58:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaChiTietDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietSanPham]    Script Date: 02/12/2023 10:58:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSanPham](
	[MaChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[LoaiSanPham] [varchar](50) NOT NULL,
	[SoLuongTrongKho] [int] NOT NULL,
	[NhaSanXuat] [varchar](100) NULL,
	[XuatXu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 02/12/2023 10:58:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaDanhGia] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[XepHang] [int] NOT NULL,
	[NhanXet] [nvarchar](250) NULL,
	[NgayDanhGia] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 02/12/2023 10:58:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[NgayDatHang] [datetime] NOT NULL,
	[TongTien] [decimal](18, 0) NOT NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 02/12/2023 10:58:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[HoTen] [varchar](30) NOT NULL,
	[DiaChi] [varchar](255) NOT NULL,
	[SoDienThoai] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE NguoiDung
ADD CONSTRAINT ND_SoDienThoaiLength CHECK (LEN(SoDienThoai) <= 15);
ALTER TABLE NguoiDung
ADD CONSTRAINT ND_SoDienThoaiIsNumeric CHECK (ISNUMERIC(SoDienThoai) = 1);
ALTER TABLE NguoiDung
ADD CONSTRAINT ND_SoDienThoaiFormat CHECK (SoDienThoai LIKE '[0-9]%');

ALTER TABLE NguoiDung
ADD CONSTRAINT ND_EmailLength CHECK (LEN(Email) <= 100);
ALTER TABLE NguoiDung
ADD CONSTRAINT ND_ValidDomain CHECK (
    SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) IN ('gmail.com', 'yahoo.com', 'example.com')
);

/****** Object:  Table [dbo].[SanPham]    Script Date: 02/12/2023 10:58:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](100) NOT NULL,
	[Gia] [decimal](18, 0) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE SanPham
ADD HinhAnh varchar(500);


/****** Object:  Table [dbo].[ThanhToan]    Script Date: 02/12/2023 10:58:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[MaThanhToan] [int] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [int] NULL,
	[NgayThanhToan] [datetime] NOT NULL,
	[SoTienThanhToan] [decimal](18, 0) NOT NULL,
	[PhuongThucThanhToan] [varchar](50) NULL,
	[MaGiaoDich] [varchar](100) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE Slide(
	MaAnh INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TieuDe NVARCHAR(250) NULL,
	MoTa NVARCHAR(250) NULL,
	LinkAnh NVARCHAR(max) NULL,
);

CREATE TABLE TaiKhoans(
	MaTaiKhoan int IDENTITY(1,1) NOT NULL,
	HoVaTen NVARCHAR(50) NULL,
	SoDienThoai VARCHAR(15) NULL,
	Email nvarchar(150) NULL,
	MatKhau nvarchar(50) NULL,
);
ALTER TABLE TaiKhoans
ADD CONSTRAINT CK_SoDienThoaiLength CHECK (LEN(SoDienThoai) <= 15);
ALTER TABLE TaiKhoans
ADD CONSTRAINT CK_SoDienThoaiIsNumeric CHECK (ISNUMERIC(SoDienThoai) = 1);
ALTER TABLE TaiKhoans
ADD CONSTRAINT CK_SoDienThoaiFormat CHECK (SoDienThoai LIKE '[0-9]%');

ALTER TABLE TaiKhoans
ADD CONSTRAINT TK_EmailLength CHECK (LEN(Email) <= 100);
ALTER TABLE TaiKhoans
ADD CONSTRAINT TK_ValidDomain CHECK (
    SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) IN ('gmail.com', 'yahoo.com', 'example.com')
);

ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietSanPham]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO




----------------------------------------------------------------------Nhập dữ liệu--------------------------------------------------------
--------Bảng NguoiDung------------
INSERT INTO NguoiDung (TenDangNhap, MatKhau, Email, HoTen, DiaChi, SoDienThoai)
VALUES 
	('nguoidung1', 'matkhau1', 'nguoidung1@gmail.com', 'Người Dùng 1', 'Địa chỉ 1', '123456789'),
	('nguoidung2', 'matkhau2', 'nguoidung2@gmail.com', 'Người Dùng 2', 'Địa chỉ 2', '987654321'),
	('nguoidung3', 'matkhau3', 'nguoidung3@gmail.com', 'Người Dùng 3', 'Địa chỉ 3', '111222333'),
	('nguoidung4', 'matkhau4', 'nguoidung4@gmail.com', 'Người Dùng 4', 'Địa chỉ 4', '444555666'),
	('nguoidung5', 'matkhau5', 'nguoidung5@gmail.com', 'Người Dùng 5', 'Địa chỉ 5', '777888999');


---------Bảng sản phẩm-----------
-- Thêm 10 bản ghi vào bảng SanPham
INSERT INTO SanPham (TenSanPham, Gia, MoTa, HinhAnh)
VALUES 
    ('Máy lọc nước', 25000000, 'Máy lọc nước khoáng thanh mát', ''),
    ('Lót cách nhiệt', 30000000, 'Lót cách nhiệt mỏng nhẹ, hiệu suất cao', ''),
    ('Bếp từ Samsung', 5000000, 'Bếp từ cao cấp', ''),
    ('Máy hút bụi Series 7', 8000000, 'Máy hút bụi thông minh của Apple', ''),
    ('Lò vi sóng', 12000000, 'Lò vi sóng công nghệ QLED với độ phân giải 4K', ''),
    ('Bếp từ', 15000000, 'Bếp từ siêu tiết kiệm điện năng', ''),
    ('Tủ lạnh LG Inverter', 10000000, 'Tủ lạnh tiết kiệm năng lượng', '/images/tu-lanh-lg.jpg'),
    ('Máy lọc không khí Xiaomi', 2000000, 'Máy lọc không khí thông minh', '/images/may-loc-khong-khi-xiaomi.jpg'),
    ('Đèn thông minh Philips Hue', 800000, 'Đèn LED thông minh có thể điều chỉnh màu sắc', '/images/den-philips-hue.jpg');

---------Bảng chi tiết sản phẩm--------
INSERT INTO ChiTietSanPham (MaSanPham, LoaiSanPham, SoLuongTrongKho, NhaSanXuat, XuatXu)
VALUES 
    (1, 'Máy nước', 50, 'Nhà sản xuất 1', 'Việt Nam'),
    (2, 'Cách nhiệt', 30, 'Nhà sản xuất 2', 'Việt Nam'),
    (3, 'Bếp', 25, 'Nhà sản xuất 3', 'Trung Quốc'),
    (4, 'Máy hút bụi', 40, 'Nhà sản xuất 4', 'Việt Nam'),
    (5, 'Lò nướng', 20, 'Nhà sản xuất 5', 'Trung Quốc'),
    (6, 'Bếp', 15, 'Nhà sản xuất 3', 'Việt Nam'),
    (7, 'Tủ lạnh', 35, 'Nhà sản xuất 7', 'Trung Quốc'),
    (8, 'Máy lọc không khí', 28, 'Nhà sản xuất 8', 'Việt Nam'),
    (9, 'Đèn điện', 22, 'Nhà sản xuất 9', 'Philippines');

---------Bảng đơn hàng----------------
-- Thêm 20 bản ghi vào bảng DonHang
INSERT INTO DonHang (MaNguoiDung, NgayDatHang, TongTien, TrangThai)
VALUES
    (6, '2023-02-01', 500000, 1),
    (8, '2023-02-02', 800000, 0),
    (10, '2023-02-03', 1200000, 1),
    (9, '2023-02-04', 300000, 0),
    (8, '2023-02-05', 1500000, 1),
    (6, '2023-02-06', 200000, 0),
    (7, '2023-02-07', 600000, 1),
    (8, '2023-02-08', 900000, 1),
    (9, '2023-02-09', 700000, 0),
    (10, '2023-02-10', 1000000, 1),
    (9, '2023-02-11', 450000, 0),
    (8, '2023-02-12', 1100000, 1),
    (7, '2023-02-13', 800000, 0),
    (6, '2023-02-14', 950000, 1),
    (10, '2023-02-15', 300000, 0),
    (6, '2023-02-16', 750000, 1),
    (7, '2023-02-17', 600000, 0),
    (8, '2023-02-18', 1200000, 1),
    (9, '2023-02-19', 400000, 0),
    (7, '2023-02-20', 900000, 1);

----------Bảng chi tiết đơn hàng---------
-- Thêm 20 bản ghi vào bảng ChiTietDonHang
INSERT INTO ChiTietDonHang (MaDonHang, MaSanPham, SoLuong, ThanhTien)
VALUES
    (12, 1, 2, 500000),
    (21, 3, 1, 800000),
    (13, 5, 3, 1200000),
    (4, 2, 4, 300000),
    (5, 7, 1, 1500000),
    (6, 8, 2, 200000),
    (7, 9, 3, 600000),
    (8, 2, 1, 900000),
    (9, 4, 2, 700000),
    (10, 6, 3, 1000000),
    (11, 8, 1, 450000),
    (12, 9, 2, 1100000),
    (13, 4, 3, 800000),
    (14, 6, 1, 950000),
    (15, 9, 2, 300000),
    (16, 1, 3, 750000),
    (17, 3, 1, 600000),
    (18, 5, 2, 1200000),
    (19, 7, 3, 400000),
    (20, 9, 1, 900000);

--------------Bảng đánh giá-----------------
-- Thêm 10 bản ghi vào bảng DanhGia
INSERT INTO DanhGia (MaSanPham, MaNguoiDung, XepHang, NhanXet, NgayDanhGia)
VALUES
    (1, 9, 4, 'Sản phẩm tốt, đáng mua', '2023-12-01'),
    (2, 8, 5, 'Rất hài lòng với chất lượng', '2023-12-02'),
    (3, 7, 3, 'Giá hơi cao nhưng chất lượng đáng giá', '2023-12-03'),
    (4, 6, 4, 'Thiết kế đẹp, sử dụng dễ dàng', '2023-12-04'),
    (5, 10, 5, 'Điều khiển bằng điện thoại rất tiện lợi', '2023-12-05'),
    (6, 6, 2, 'Chưa hài lòng với dịch vụ giao hàng', '2023-12-06'),
    (7, 7, 4, 'Tủ lạnh chạy êm, không gian rộng rãi', '2023-12-07'),
    (8, 8, 5, 'Máy lọc không khí hoạt động tốt', '2023-12-08'),
    (9, 9, 3, 'Chất lượng sản phẩm khá ổn định', '2023-12-09'),
    (1, 10, 4, 'Thiết kế đẹp mắt, sử dụng linh hoạt', '2023-12-10');


-------------bảng slide----------------
INSERT INTO Slide (TieuDe, MoTa, LinkAnh)
VALUES
    ('Slide 1', 'Mô tả cho Slide 1', '/images/slide1.jpg'),
    ('Slide 2', 'Mô tả cho Slide 2', '/images/slide2.jpg'),
    ('Slide 3', 'Mô tả cho Slide 3', '/images/slide3.jpg'),
    ('Slide 4', 'Mô tả cho Slide 4', '/images/slide4.jpg'),
    ('Slide 5', 'Mô tả cho Slide 5', '/images/slide5.jpg');



--------------Bảng thanh toán------------
-- Thêm 20 bản ghi vào bảng ThanhToan
INSERT INTO ThanhToan (MaDonHang, NgayThanhToan, SoTienThanhToan, PhuongThucThanhToan, MaGiaoDich, TrangThai)
VALUES
    (21, '2023-12-01', 5000000, 'Credit Card', 'GD123456', 1),
    (22, '2023-12-02', 7000000, 'PayPal', 'GD789012', 1),
    (3, '2023-12-03', 12000000, 'Cash', 'GD345678', 0),
    (4, '2023-12-04', 8500000, 'Credit Card', 'GD901234', 1),
    (5, '2023-12-05', 3000000, 'Cash', 'GD567890', 1),
    (6, '2023-12-06', 6000000, 'Credit Card', 'GD123987', 0),
    (7, '2023-12-07', 9500000, 'PayPal', 'GD654321', 1),
    (8, '2023-12-08', 4000000, 'Cash', 'GD234567', 1),
    (9, '2023-12-09', 11000000, 'Credit Card', 'GD876543', 1),
    (10, '2023-12-10', 7500000, 'PayPal', 'GD345678', 0),
    (11, '2023-12-11', 4800000, 'Cash', 'GD901234', 1),
    (12, '2023-12-12', 9200000, 'Credit Card', 'GD567890', 1),
    (13, '2023-12-13', 6300000, 'Cash', 'GD123987', 0),
    (14, '2023-12-14', 7700000, 'Credit Card', 'GD654321', 1),
    (15, '2023-12-15', 8900000, 'PayPal', 'GD234567', 1),
    (16, '2023-12-16', 5200000, 'Cash', 'GD876543', 1),
    (17, '2023-12-17', 9800000, 'Credit Card', 'GD345678', 0),
    (18, '2023-12-18', 6300000, 'PayPal', 'GD901234', 1),
    (19, '2023-12-19', 7700000, 'Cash', 'GD567890', 1),
    (20, '2023-12-20', 11000000, 'Credit Card', 'GD123987', 0);



-----------------------------------------------------Stored Procedures-------------------------------------
---get id from table SanPham---
CREATE PROCEDURE [dbo].[sp_sanpham_get_by_id](@MaSanPham int)
AS
    BEGIN
        SELECT s.*, 
        (
            SELECT top 6 sp.*
            FROM SanPham AS sp
            WHERE sp.TenSanPham = s.TenSanPham FOR JSON PATH
        ) AS list_json_sanphamlienquan
        FROM SanPham AS s
        WHERE  s.MaSanPham = @MaSanPham;
    END;
---search product----------
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
            s.HinhAnh
        INTO #Results1
        FROM SanPham AS s
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
            s.HinhAnh
        INTO #Results2
        FROM SanPham AS s
        WHERE
            (@ten_sanpham = '' OR s.TenSanPham LIKE N'%' + @ten_sanpham + '%');   
        SELECT @RecordCount = COUNT(*) FROM #Results2;

        SELECT *,
               @RecordCount AS RecordCount
        FROM #Results2;
    END;
END;

---------------Create product-----------
CREATE PROCEDURE [dbo].[sp_san_pham_create](
@TenSanPham nvarchar(100),
@Gia decimal(18, 0),
@MoTa nvarchar(MAX),
@HinhAnh varchar(500)
)
AS
    BEGIN
       insert into SanPham(TenSanPham,Gia,MoTa,HinhAnh)
	   values(@TenSanPham,@Gia,@MoTa,@HinhAnh);
    END;


------------Update product------------
USE [GiaDungPlus]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_san_pham_update](
    @MaSanPham INT,
    @TenSanPham NVARCHAR(100),
    @Gia DECIMAL(18, 0),
    @MoTa NVARCHAR(MAX),
    @HinhAnh VARCHAR(500)
)
AS
BEGIN
    IF @MaSanPham IS NOT NULL
    BEGIN
        UPDATE SanPham
        SET TenSanPham = ISNULL(@TenSanPham, TenSanPham),
            Gia = ISNULL(@Gia, Gia),
            MoTa = ISNULL(@MoTa, MoTa),
            HinhAnh = ISNULL(@HinhAnh, HinhAnh)
        WHERE MaSanPham = @MaSanPham;
    END;
END;


----------------Delete product-----------------
CREATE PROCEDURE [dbo].[sp_san_pham_delete](
    @MaSanPham int
)
AS
BEGIN
    DELETE FROM SanPham WHERE MaSanPham = @MaSanPham;
END;
