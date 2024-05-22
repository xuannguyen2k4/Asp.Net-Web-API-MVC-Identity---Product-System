﻿CREATE DATABASE QLBANHANG
GO

USE QLBANHANG;
GO

-- Tạo bảng tblKhachhang
CREATE TABLE tblKhachhang (
    KH_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	KH_Ma NVARCHAR(100),
    KH_Ten NVARCHAR(100),
    KH_Diachi NVARCHAR(100),
    KH_Email NVARCHAR(100),
    KH_SĐT CHAR(10),
    KH_Ngaysinh DATE,
    KH_Ngaythamgia DATE,
    KH_Matkhau NVARCHAR(50),
    KH_Gioitinh NVARCHAR(10)
);

-- Thêm dữ liệu vào bảng tblKhachhang
INSERT INTO tblKhachhang (KH_Ma, KH_Ten, KH_Diachi, KH_Email, KH_SĐT, KH_Ngaysinh, KH_Ngaythamgia, KH_Matkhau, KH_Gioitinh)
VALUES 
    (N'KH01', N'Nguyễn Văn A', N'123 Đường ABC, Quận XYZ, Thành phố HCM', 'nguyenvana@example.com', '0123456789', '2000-01-01', '2024-05-12', 'password1', 'Nam'),
    (N'KH02',N'Trần Thị B', N'456 Đường DEF, Quận UVW, Thành phố Hanoi', 'tranthib@example.com', '0987654321', '1995-06-15', '2024-05-11', 'password2', 'Nữ'),
    (N'KH03',N'Lê Văn C', N'789 Đường GHI, Quận JKL, Thành phố Hanoi', 'levanc@example.com', '0369852147', '1988-03-20', '2024-05-10', 'password3', 'Nam'),
    (N'KH04',N'Phạm Thị D', N'101 Đường MNO, Quận PQR, Thành phố HCM', 'phamthid@example.com', '0901234567', '1999-12-05', '2024-05-09', 'password4', 'Nữ'),
    (N'KH05',N'Hoàng Văn E', N'111 Đường STU, Quận VWX, Thành phố Hanoi', 'hoangvane@example.com', '0987654321', '1992-08-25', '2024-05-08', 'password5', 'Nam');


-- Tạo bảng tblNhacungcap
CREATE TABLE tblNhacungcap (
    CC_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	CC_Ma NVARCHAR(100),
    CC_TenNCC NVARCHAR(100),
    CC_Diachi NVARCHAR(100),
    CC_SĐT CHAR(10)
);

-- Thêm dữ liệu vào bảng tblNhacungcap
INSERT INTO tblNhacungcap (CC_Ma, CC_TenNCC, CC_Diachi, CC_SĐT)
VALUES 
    (N'NCC01', N'Công ty A', N'123 Đường ABC, Quận XYZ, Thành phố HCM', '0123456789'),
    (N'NCC02', N'Công ty B', N'456 Đường DEF, Quận UVW, Thành phố Hanoi', '0987654321'),
    (N'NCC03', N'Công ty C', N'789 Đường GHI, Quận JKL, Thành phố Hanoi', '0369852147'),
    (N'NCC04', N'Công ty D', N'101 Đường MNO, Quận PQR, Thành phố HCM', '0901234567'),
    (N'NCC05', N'Công ty E', N'111 Đường STU, Quận VWX, Thành phố Hanoi', '0987654321');


-- Tạo bảng tblSanpham
CREATE TABLE tblSanpham (
    SP_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	SP_Ma NVARCHAR(100),
    SP_TenSP NVARCHAR(100),
    SP_Mota NVARCHAR(100),
	SP_Donvi NVARCHAR(100),
    SP_Giaban float,
	SP_NSX DATE,
	SP_HSD DATE,
	SP_CC_ID UNIQUEIDENTIFIER,
	FOREIGN KEY (SP_CC_ID) REFERENCES tblNhacungcap(CC_ID) 
);

-- Thêm dữ liệu vào bảng tblSanpham
INSERT INTO tblSanpham (SP_Ma, SP_TenSP, SP_Mota, SP_Donvi, SP_Giaban, SP_NSX, SP_HSD, SP_CC_ID)
VALUES 
    (N'SP01', N'Sản phẩm A', N'Mô tả sản phẩm A', N'Cái', 100000, '2024-01-01', '2025-01-01', 'C2A53C41-C6E9-42FE-AD0A-772C7601CA1D'),
    (N'SP02', N'Sản phẩm B', N'Mô tả sản phẩm B', N'Chiếc', 150000, '2024-02-01', '2025-02-01', 'C79DF894-D04C-4519-853D-AEFC32908AFD'),
    (N'SP03', N'Sản phẩm C', N'Mô tả sản phẩm C', N'Bộ', 200000, '2024-03-01', '2025-03-01', 'DD829F64-11A3-4818-BFC6-D2FDB0E91267'),
    (N'SP04', N'Sản phẩm D', N'Mô tả sản phẩm D', N'Cái', 120000, '2024-04-01', '2025-04-01', 'C725A159-A09A-488F-96B5-F48DDB5705C8'),
    (N'SP05', N'Sản phẩm E', N'Mô tả sản phẩm E', N'Chiếc', 180000, '2024-05-01', '2025-05-01', '6BF892C5-7515-4C58-BF8C-F9623A7A07FE');



-- Tạo bảng tblDonviVC
CREATE TABLE tblDonviVC (
    VC_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	VC_Ma NVARCHAR(100),
    VC_Ten NVARCHAR(100),
	VC_SĐT CHAR(10),
	VC_Diachilienlac NVARCHAR(100),
);

-- Thêm dữ liệu vào bảng tblKH_DonviVC_NCC
INSERT INTO tblDonviVC (VC_Ma, VC_Ten, VC_SĐT, VC_Diachilienlac) VALUES
(N'VC01',N'Cong ty VC 1', '0123456789', '789 Duong DEF, Da Nang'),
(N'VC02',N'Cong ty VC 2', '0987654321', '101 Duong GHI, Hue'),
(N'VC03',N'Donvi VC 3', '0123456789', '123 Nguyen Trai, District 1, HCMC'),
(N'VC04',N'Donvi VC 4', '0987654321', '456 Le Loi, District 3, HCMC'),
(N'VC05',N'Donvi VC 5', '0234567890', '789 Tran Hung Dao, District 5, HCMC'),
(N'VC06',N'Donvi VC 6', '0345678901', '1011 Pham Ngu Lao, District 1, HCMC'),
(N'VC07',N'Donvi VC 7', '0456789012', '1213 Hai Ba Trung, District 3, HCMC');


-- Tạo bảng tblNhanvien
CREATE TABLE tblNhanvien (
    NV_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	NV_Ma NVARCHAR(100),
    NV_Ten NVARCHAR(100),
    NV_Diachi NVARCHAR(100),
    NV_Email NVARCHAR(100),
    NV_SĐT CHAR(10),
    NV_Ngaysinh DATE,
    NV_Ngaythamgia DATE,
    NV_Matkhau NVARCHAR(50),
    NV_Gioitinh NVARCHAR(10),
);

INSERT INTO tblNhanvien (NV_Ma, NV_Ten, NV_Diachi, NV_Email, NV_SĐT, NV_Ngaysinh, NV_Ngaythamgia, NV_Matkhau, NV_Gioitinh) VALUES
(N'NV01', N'Nguyen Van A', '123 Duong ABC, Ha Noi', 'nva@example.com', 123456789, '1980-01-01', '2023-01-01', 'pass123', 'Nam'),
(N'NV02', N'Tran Thi B', '456 Duong XYZ, TP HCM', 'ttb@example.com', 987654321, '1990-02-02', '2023-02-02', 'pass456', 'Nu'),
(N'NV01',N'Nguyen Dieu A', '123 Le Loi, District 1, HCMC', 'nguyenvana@example.com', 1234567890, '1985-05-10', '2010-04-15', 'password123', 'Nam'),
(N'NV01',N'Tran Hoang B', '456 Tran Hung Dao, District 5, HCMC', 'tranthib@example.com', 9876543210, '1990-08-25', '2012-08-20', 'securepass', 'Nu'),
(N'NV01',N'Le Van C', '789 Nguyen Trai, District 3, HCMC', 'levanc@example.com', 1122334455, '1988-12-15', '2011-02-10', 'mypassword', 'Nam'),
(N'NV01',N'Pham Thi D', '1011 Hai Ba Trung, District 1, HCMC', 'phamthid@example.com', 2233445566, '1992-03-22', '2013-06-18', 'password321', 'Nu'),
(N'NV01',N'Hoang Van E', '1213 Pham Ngu Lao, District 1, HCMC', 'hoangvane@example.com', 3344556677, '1983-11-30', '2009-11-05', 'strongpass', 'Nam'),
(N'NV01',N'Vu Thi F', '1415 Le Duan, District 3, HCMC', 'vuthif@example.com', 4455667788, '1989-07-18', '2014-03-25', 'mypassword1', 'Nu'),
(N'NV01',N'Nguyen Van G', '1617 Le Loi, District 5, HCMC', 'nguyenvang@example.com', 5566778899, '1986-01-10', '2010-12-12', 'password456', 'Nam'),
(N'NV01',N'Do Thi H', '1819 Nguyen Trai, District 1, HCMC', 'dothih@example.com', 6677889900, '1991-05-05', '2015-09-30', 'secure1234', 'Nu'),
(N'NV01',N'Bui Van I', '2021 Tran Hung Dao, District 3, HCMC', 'buivani@example.com', 7788990011, '1987-10-20', '2011-07-07', 'pass1234', 'Nam'),
(N'NV01',N'Ngo Thi K', '2223 Hai Ba Trung, District 5, HCMC', 'ngothik@example.com', 8899001122, '1993-09-09', '2016-05-18', 'mypassword789', 'Nu');


--Tạo bảng tblPhieunhap
CREATE TABLE tblPhieunhap(
	PN_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	PN_Ma NVARCHAR(100),
	PN_Ngaynhap DATE,
	PN_Tien float,
	PN_NCC_ID UNIQUEIDENTIFIER,
	PN_NV_ID UNIQUEIDENTIFIER,
	FOREIGN KEY (PN_NCC_ID) REFERENCES tblNhacungcap(CC_ID),
	FOREIGN KEY (PN_NV_ID) REFERENCES tblNhanvien(NV_ID)
);

INSERT INTO tblPhieunhap (PN_Ma, PN_Ngaynhap, PN_Tien, PN_NCC_ID, PN_NV_ID) VALUES
(N'PN01', '2024-05-01',1500000, 'C2A53C41-C6E9-42FE-AD0A-772C7601CA1D', 'DD7EC78C-5AF4-4AD7-A3F0-0995C40DF11C'), 
(N'PN02','2024-05-02',4000000, 'C2A53C41-C6E9-42FE-AD0A-772C7601CA1D', '141FC886-75D6-46C5-BB66-1EBA36B8AAAB'),
(N'PN03','2024-05-03',1000000 , 'C79DF894-D04C-4519-853D-AEFC32908AFD', '598B8207-D145-4E5A-A58C-223FB1082105'),
(N'PN04','2024-05-04',340000 , 'DD829F64-11A3-4818-BFC6-D2FDB0E91267', 'C84DBB29-E35B-411F-A273-39BADF58269D'),
(N'PN05','2024-05-05',270000 , 'C725A159-A09A-488F-96B5-F48DDB5705C8', 'A71CDAAC-1266-4762-8F00-6A0A3E5795B9'),
(N'PN06','2024-05-06',228000 , 'C725A159-A09A-488F-96B5-F48DDB5705C8', 'CA4D6BEB-E0EA-42A2-B435-C0970E9D161D'),
(N'PN07','2024-05-07',900000 , '6BF892C5-7515-4C58-BF8C-F9623A7A07FE', '4DD5721A-9EB6-4E3F-B83B-E7CD76C33428');

INSERT INTO tblPhieunhap (PN_Ma, PN_Ngaynhap,PN_NCC_ID, PN_NV_ID) VALUES
(N'PN08','2024-05-08', '6BF892C5-7515-4C58-BF8C-F9623A7A07FE', '4DD5721A-9EB6-4E3F-B83B-E7CD76C33428');

INSERT INTO tblPhieunhap (PN_Ma, PN_Ngaynhap,PN_NCC_ID, PN_NV_ID) VALUES
(N'PN09','2024-05-09', '6BF892C5-7515-4C58-BF8C-F9623A7A07FE', '4DD5721A-9EB6-4E3F-B83B-E7CD76C33428');


--Tạo bảng tblPhieunhapCT
CREATE TABLE tblPhieunhapCT(
	CTN_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	CTN_Ma NVARCHAR(100),
	CTN_Gianhap float,
	CTN_Soluong int,
	CTN_Tongtien float,
	CTN_SP_ID UNIQUEIDENTIFIER,
	CTN_NCC_ID UNIQUEIDENTIFIER,
	CTN_PN_ID UNIQUEIDENTIFIER,
	FOREIGN KEY (CTN_SP_ID) REFERENCES tblSanpham(SP_ID),
	FOREIGN KEY (CTN_NCC_ID) REFERENCES tblNhacungcap(CC_ID),
	FOREIGN KEY (CTN_PN_ID) REFERENCES tblPhieunhap(PN_ID),
);


INSERT INTO tblPhieunhapCT (CTN_Ma, CTN_SP_ID, CTN_Gianhap, CTN_Soluong, CTN_Tongtien, CTN_NCC_ID,CTN_PN_ID) VALUES
(N'CTN01', 'EB8881F3-1888-42A3-A44D-21942B0C6F30', 15000, 100,1500000,'C2A53C41-C6E9-42FE-AD0A-772C7601CA1D' , '94799A62-E7B8-4A04-B805-058C027B359E'), 
(N'CTN02','EB8881F3-1888-42A3-A44D-21942B0C6F30', 20000, 200,4000000,'C79DF894-D04C-4519-853D-AEFC32908AFD' , '6FD80735-2D23-45FB-B186-17BC40998DD2'),
(N'CTN03','0E6FABCD-34E9-4734-8857-54A8539CC5BD', 10000, 10,1000000,'DD829F64-11A3-4818-BFC6-D2FDB0E91267' , 'B63A0765-167F-44CF-80C2-1AEC23A4BEDD'),
(N'CTN04','1F458292-6B64-4FE8-B653-7BAD00628336', 17000, 20,340000,'C725A159-A09A-488F-96B5-F48DDB5705C8' , 'CFAE5E40-061C-46BD-9289-333F2A20F06D'),
(N'CTN05','5D8FAFB9-516F-45A3-9575-B248E577E878', 18000, 15,270000,'6BF892C5-7515-4C58-BF8C-F9623A7A07FE' , '8EF0F3EF-C15D-446B-BE3D-45A68476FB31'),
(N'CTN06','33C5B2B0-C57A-4F7B-BB68-C94813566DA7', 19000, 12,228000,'C725A159-A09A-488F-96B5-F48DDB5705C8' , '7174AB22-79D3-4DFA-B1C6-6BA6435A7346'),
(N'CTN07','5D8FAFB9-516F-45A3-9575-B248E577E878', 30000, 30,900000,'C2A53C41-C6E9-42FE-AD0A-772C7601CA1D' , '1E6526E5-14DA-43DF-95EC-FDAC610FCA31');

INSERT INTO tblPhieunhapCT (CTN_Ma, CTN_SP_ID, CTN_Gianhap, CTN_Soluong, CTN_Tongtien, CTN_NCC_ID,CTN_PN_ID) VALUES
(N'CTN08','5D8FAFB9-516F-45A3-9575-B248E577E878', 20000, 30,600000,'C79DF894-D04C-4519-853D-AEFC32908AFD' , '1A5244A3-A56D-4C66-BD8C-6DB7F47AD6B5');

INSERT INTO tblPhieunhapCT (CTN_Ma, CTN_SP_ID, CTN_Gianhap, CTN_Soluong, CTN_Tongtien, CTN_NCC_ID,CTN_PN_ID) VALUES
(N'CTN09','5D8FAFB9-516F-45A3-9575-B248E577E878', 40000, 30,1200000,'C79DF894-D04C-4519-853D-AEFC32908AFD' , '774FEEE8-2125-4046-8B9A-43E547490D2C');


CREATE TRIGGER [dbo].[TG_UPDATE_TIEN1]
   ON  [dbo].[tblPhieunhapCT]
   AFTER INSERT, UPDATE, DELETE
AS 
BEGIN
    SET NOCOUNT ON;

    -- Declare a table variable to store the affected PN_IDs
    DECLARE @AffectedPhieuNhap TABLE (PN_ID UNIQUEIDENTIFIER);

    -- Insert the affected PN_IDs from the inserted table
    INSERT INTO @AffectedPhieuNhap (PN_ID)
    SELECT DISTINCT CTN_PN_ID 
    FROM inserted 
    WHERE CTN_PN_ID IS NOT NULL;

    -- Insert the affected PN_IDs from the deleted table
    INSERT INTO @AffectedPhieuNhap (PN_ID)
    SELECT DISTINCT CTN_PN_ID 
    FROM deleted 
    WHERE CTN_PN_ID IS NOT NULL;

    -- Update the PN_Tien in tblPhieunhap for each affected PN_ID
    UPDATE pn
    SET PN_Tien = (SELECT SUM(CTN_Gianhap * CTN_Soluong) 
                   FROM tblPhieunhapCT 
                   WHERE CTN_PN_ID = pn.PN_ID)
    FROM tblPhieunhap pn
    WHERE PN_ID IN (SELECT PN_ID FROM @AffectedPhieuNhap);

END
GO


-- Tạo bảng tblDonhang
CREATE TABLE tblDonhang (
    DH_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	DH_Ma NVARCHAR(100),
    DH_KH_ID UNIQUEIDENTIFIER,
    DH_DVCC_ID UNIQUEIDENTIFIER,
    DH_NgayDatHang DATETIME,			
    DH_TrangThai NVARCHAR(100),
    DH_NgayDuKien DATETIME,
    DH_NgayThuc DATETIME,
	DH_NV_ID UNIQUEIDENTIFIER,
	FOREIGN KEY (DH_NV_ID) REFERENCES tblNhanvien(NV_ID),
    FOREIGN KEY (DH_KH_ID) REFERENCES tblKhachhang(KH_ID),
    FOREIGN KEY (DH_DVCC_ID) REFERENCES tblDonviVC(VC_ID),
);

INSERT INTO tblDonhang (DH_Ma, DH_KH_ID, DH_DVCC_ID, DH_NgayDatHang, DH_TrangThai, DH_NgayDuKien, DH_NgayThuc, DH_NV_ID) VALUES
(N'DH01', '0D9ED923-BC41-474B-BD85-1F8641BF65D8', 'ACA3E199-6FFC-4AE7-A9BB-228248FCF6F6', '2024-05-01', 'Pending', '2024-05-05', NULL, 'DD7EC78C-5AF4-4AD7-A3F0-0995C40DF11C'), 
(N'DH02','0D9ED923-BC41-474B-BD85-1F8641BF65D8', '39F22008-957B-4F95-9E9F-7057231717E8', '2024-05-02', 'Shipped', '2024-05-06', '2024-05-06', '141FC886-75D6-46C5-BB66-1EBA36B8AAAB'),
(N'DH03','09D6298B-34A2-4ECF-97C0-73F0391871BE', 'CBFC29C0-EF43-41D5-B534-72004D7D51CD', '2024-01-01', 'Pending', '2024-01-05', NULL, '598B8207-D145-4E5A-A58C-223FB1082105'),
(N'DH04','E140E674-95A2-4CA6-B143-9CA0CDEC384B', '0C8E8991-6FF8-4E7C-B520-862C77C40F32', '2024-01-02', 'Shipped', '2024-01-06', '2024-01-07', 'A815CF73-B566-4C3C-8E6F-DEF80C933875'),
(N'DH05','95D4ABBD-0630-4351-8513-B80DB8DA4268', '53CEF388-8F94-4094-BFAC-8CDE1E405FB8', '2024-01-03', 'Delivered', '2024-01-07', '2024-01-08', '4DD5721A-9EB6-4E3F-B83B-E7CD76C33428'),
(N'DH06','E140E674-95A2-4CA6-B143-9CA0CDEC384B', '5DFC08A7-9627-400F-9FDF-AAEAF50696A4', '2024-01-04', 'Canceled', '2024-01-08', NULL, 'A815CF73-B566-4C3C-8E6F-DEF80C933875'),
(N'DH07','E140E674-95A2-4CA6-B143-9CA0CDEC384B', '619B707C-1F54-48CC-A468-E06116631AC4', '2024-01-05', 'Pending', '2024-01-09', NULL, '4DD5721A-9EB6-4E3F-B83B-E7CD76C33428');


-- Tạo bảng tblCTDonhang
CREATE TABLE tblCTDonhang (
	CT_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	CT_Ma NVARCHAR(100),
    CT_DH_ID UNIQUEIDENTIFIER,
    CT_SP_ID UNIQUEIDENTIFIER,
	CT_GiaSP float,
	CT_Soluong int,
    FOREIGN KEY (CT_SP_ID) REFERENCES tblSanpham(SP_ID),
	FOREIGN KEY (CT_DH_ID) REFERENCES tblDonhang(DH_ID),
);


INSERT INTO tblCTDonhang (CT_Ma, CT_DH_ID, CT_SP_ID, CT_GiaSP, CT_Soluong) VALUES
(N'CT01', '9871A82C-7693-4DF0-9E31-029334E9AC2D', 'EB8881F3-1888-42A3-A44D-21942B0C6F30', 15000, 2), 
(N'CT01','799993E0-4109-4758-8C36-418E94D71BDB', '0E6FABCD-34E9-4734-8857-54A8539CC5BD', 20000, 1),
('CT03', '17FE3011-2E1A-46FB-8BDB-6E6CB4E28C5D', '0E6FABCD-34E9-4734-8857-54A8539CC5BD', 16000, 10),
('CT04', 'BC510E73-1ADA-4349-90FA-74564D0B02C1', '1F458292-6B64-4FE8-B653-7BAD00628336', 21000, 5),
('CT05', 'D7D29FF8-8D7B-455D-9323-B53821659BB2', '5D8FAFB9-516F-45A3-9575-B248E577E878', 17000, 8),
('CT06', '4922DCC9-DF3B-435B-8BE5-E03114909E4A', '33C5B2B0-C57A-4F7B-BB68-C94813566DA7', 30000, 3),
('CT07', '221DE976-15AF-4B12-9064-E30C4E98052F', '5D8FAFB9-516F-45A3-9575-B248E577E878', 10000, 20);