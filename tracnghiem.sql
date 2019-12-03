go
create database THI_TN
go
use THI_TN
-----------------Create tables-------------------

go
create table CoSo(
	MACS nvarchar(3),
	TENCS nvarchar(40) unique,
	DIACHI nvarchar(100),
	primary key(MACS)
)
go
create table Khoa(
	MAKH char(10),
	TENKH nvarchar(40) unique,
	MACS nvarchar(3),
	primary key(MAKH)
)
go
alter table Khoa add constraint Khoa_CoSo foreign key(MACS) references CoSo(MACS)
go
create table Lop(
	MALOP char(10),
	TENLOP varchar(50) unique,
	MAKH char(10),
	primary key(MALOP)
)
go
alter table Lop add constraint Lop_Khoa foreign key(MAKH) references Khoa(MAKH)
go
create table MonHoc(
	MAMH char(6),
	TENMH varchar(40) unique,
	primary key(MAMH)
)
go
create table SinhVien(
	MASV char(10),
	MATKHAU varchar(50),
	HO varchar(50),--Có điều kiện: Chỉ nhận chữ và blank
	TEN varchar(10),
	NGAYSINH DateTime,
	DIACHI varchar(40),
	MALOP char(10),
	primary key(MASV)
)
go
alter table SinhVien add constraint SinhVien_Lop foreign key(MALOP) references LOP(MALOP)
go
create table GiaoVien(
	MAGV char(10),
	MATKHAU varchar(50),
	HO varchar(40),
	TEN varchar(10),
	HOCVI varchar(40),
	MAKH char(10),
	primary key(MAGV)
)
go
alter table GiaoVien add constraint GiaoVien_Khoa foreign key(MAKH) references Khoa(MAKH)
go
create table GiaoVien_DangKy(
	MAGV char(10),
	MALOP char(10),
	MAMH char(6),
	TRINHDO char(1)
			check(TRINHDO in ('A', 'B', 'C')),--'A','B','C'
	NGAYTHI datetime,--getdate
	LAN smallint
		check (LAN >= 1 and LAN <= 2),--Lần thi >= 1 và lần thi <= 2
	SOCAUTHI smallint
		check (SOCAUTHI >= 10 and SOCAUTHI <= 100),-- >= 10 và <= 100
	THOIGIAN smallint
		check (THOIGIAN >= 15 and THOIGIAN <= 60),-- >= 15 và <= 60
	primary key(MALOP,MAMH,LAN)
)
go
alter table GiaoVien_DangKy add constraint GiaoVienDK_GiaoVien foreign key(MAGV) references GiaoVien(MAGV)
go
alter table GiaoVien_DangKy add constraint GiaoVienDK_Lop foreign key(MALOP) references Lop(MALOP)
go
alter table GiaoVien_DangKy add constraint GiaoVienDK_MonHoc foreign key(MAMH) references MonHoc(MAMH)
go
create table BoDe(
	MAMH char(6),
	CAUHOI int,
	TRINHDO char(1)
			check(TRINHDO in ('A', 'B', 'C')),
			--'A': Đại học, chuyên ngành
			--'B': Đại học, không chuyên ngành
			--'C': Cao đẳng
	NOIDUNG text,
	A varchar(30),
	B varchar(30),
	C varchar(30),
	D varchar(30),
	DAPAN char(1)
		  check(DAPAN in ('A', 'B', 'C', 'D')),--'A','B','C','D'
	MAGV char(10),
	primary key(CAUHOI)
)
go
alter table BoDe add constraint BoDe_MonHoc foreign key(MAMH) references MonHoc(MAMH)
go
alter table BoDe add constraint BoDe_GiangVien foreign key(MAGV) references GiaoVien(MAGV)
go
create table BangDiem(
	MASV char(10),
	MAMH char(6),
	LAN smallint
		check(LAN >= 1 and LAN <= 2),-- >= 1 và <= 2
	NGAYTHI datetime,
	DIEM float
		check(DIEM >= 0.0 and DIEM <= 10.0),-- 0 <= DIEM <= 10
	BAITHI text,
	primary key(MASV,MAMH,LAN)
)
go
alter table BangDiem add constraint BangDiem_SinhVien foreign key(MASV) references SinhVien(MASV)
go
alter table BangDiem add constraint BangDiem_MonHoc foreign key(MAMH) references MonHoc(MAMH)
----------------------Insert-------------------	

go
Insert into CoSo values ('CS1',N'Cơ sở 1',N'Quận 7'),
						('CS2',N'Cơ sở 2',N'Bảo Lộc')
go
Insert into Khoa values ('CNTT',N'Công nghệ thông tin','CS1'),
						('KTCT',N'Kỹ thuật Công Trình','CS2'),
						('QTKD',N'Quản trị kinh doanh','CS2'),
						('MTCN',N'Mỹ thuật công nghiệp','CS1'),
						('XHNV',N'Xã hội nhân văn','CS1'),
						('NNA',N'Ngôn ngữ Anh','CS1'),
						('NNT',N'Ngôn ngữ Trung','CS2'),
						('NNTA',N'Ngôn ngữ Trung ANh','CS2'),
						('L',N'Luật','CS1'),
						('D',N'Điện','CS2'),
						('YD',N'Y Dược','CS1'),
						('KHUD',N'Khoa học ứng dụng','CS2'),
						('KHTT',N'Khoa học thể thao','CS1')
go
Insert into Lop values ('17050301','Khoa hoc may tinh 01','CNTT'),
					   ('17050302','Khoa hoc may tinh 02','CNTT'),
					   ('17050303','Khoa hoc may tinh 03','CNTT'),
					   ('17040301','Tu dong hoa 01','D'),
					   ('17040302','Tu dong hoa 02','D'),
					   ('17040303','Tu dong hoa 03','D'),
					   ('17020301','Quan tri nha hang khach san 01','QTKD'),
					   ('17020302','Quan tri nha hang khach san 02','QTKD'),
					   ('17020303','Quan tri nha hang khach san 03','QTKD'),
					   ('17030301','Luat cong ty 01','L'),
					   ('17030302','Luat cong ty 02','L'),
					   ('17030303','Luat cong ty 03','L'),
					   ('17010301','Quan he cong chung 01','XHNV'),
					   ('17010302','Quan he cong chung 02','XHNV'),
					   ('17010303','Quan he cong chung 03','XHNV'),
					   ('17060301','Cong nghe sinh hoc 01','KHUD'),
					   ('17060302','Cong nghe sinh hoc 02','KHUD'),
					   ('17060303','Cong nghe sinh hoc 03','KHUD')
go
Insert into MonHoc values ('502052','Phat trien HTTT doanh nghiep'),
						  ('504068','Co so du lieu phan tan'),
						  ('502051','He co so du lieu'),
						  ('502045','Cong nghe phan mem'),
						  ('503073','Lap trinh web va ung dung')
go
Insert into SinhVien values ('51703127','123','Le Huu','Luan','1/2/1999','TpHCM','17050303'),
							('51703066','123','Le Nhat','Duy','1/2/1999','TpHCM','17040301'),
							('51703113','123','Nguyen Dang','Khoa','1/2/1999','TpHCM','17030302'),
							('51703138','123','Ton Nu Thuy','Ngan','1/2/1999','TpHCM','17020303'),
							('51703172','123','Pham Nguyen Thanh','Sang','1/2/1999','TpHCM','17010302'),
							('51703070','123','Nguyen Ngoc Hoang','Gia','1/2/1999','TpHCM','17060301')
go
Insert into GiaoVien values ('GV01','123','Tran Thi','A','Thac Si','QTKD'),
							('GV02','123','Tran Van','B','Thac Si','CNTT'),
							('GV03','123','Tran ','C','Thac Si','KTCT'),
							('GV04','123','Tran Anh','D','Thac Si','MTCN'),
							('GV05','123','Tran My','E','Thac Si','XHNV'),
							('GV06','123','Tran Thanh','G','Thac Si','D'),
							('GV07','123','Tran Thanh','U','Thac Si','D')
go
Insert into GiaoVien_DangKy values ('GV01','17020303','502052','A','1/11/2019',1,20,15),
								   ('GV02','17050303','502045','B','1/11/2019',1,30,20),
								   ('GV03','17040301','504068','C','1/11/2019',1,40,45),
								   ('GV04','17030303','502051','A','1/11/2019',1,20,15),
								   ('GV05','17010302','503073','B','1/11/2019',1,20,20),
								   ('GV06','17060301','502052','C','1/11/2019',1,50,60)
go
Insert into BoDe values ('502052',1,'A','Cau hoi 1','A','B','C','D','A','GV01'),
						('502045',2,'B','Cau hoi 2','A','B','C','D','B','GV02'),
						('504068',3,'C','Cau hoi 3','A','B','C','D','C','GV03'),
						('502051',4,'A','Cau hoi 4','A','B','C','D','A','GV04'),
						('503073',5,'B','Cau hoi 5','A','B','C','D','B','GV05'),
						('502052',6,'C','Cau hoi 6','A','B','C','D','C','GV06')