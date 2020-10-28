create table Pegawai 
(
   USERNAME_USER varchar2(1024) CONSTRAINT PK_USER PRIMARY KEY,
   PASSWORD varchar2(1024) null,
   NAMA_USER varchar2(1024) null,
   POSISI varchar2(200) null,
   ALAMAT_USER varchar2(1024) null,
   KONTAK_USER varchar2(12) null
);





insert into Pegawai values ('admin','admin','admin','Admin','jl.admin','2');


insert into jeniskamar values ('S01','STANDARD',110000);

SELECT USERNAME_USER, password " +
   "FROM Pegawai " +
   "WHERE USERNAME_USER='" + usernameLogin + "'" +
   "AND password = '" + pass + "' " +
   "AND posisi = "'Admin'", conn);

select USERNAME_USER, password from pegawai where USERNAME_USER = 'admin' and password = 'admin';



create table INPUT_PART
(
   KODE_BARANG varchar(1024) CONSTRAINT PK_INPUT_PART PRIMARY KEY,
   NAMA_BARANG varchar(1024) null,
   SATUAN_BARANG integer null,
   HARGA_BARANG integer null,
   KODE_TEMPAT varchar(1024) null
);