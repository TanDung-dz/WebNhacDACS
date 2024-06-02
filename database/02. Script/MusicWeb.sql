use master
go
create database WebNhac
go
use WebNhac
go
Create table [Menu]
(
	[id_menu] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[name] Nvarchar(255) NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL,
	[id_admin] Integer NOT NULL
) 
go

Create table [User]
(
	[id_user] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[username] Varchar(255) NULL,
	[password] Varchar(255) NULL,
	[name] Nvarchar(255) NULL,
	[email] Varchar(255) NULL,
	[phone] Varchar(11) NULL,
	[hide] Bit NULL,
	[link] Varchar(255) NULL
) 
go

Create table [SlideShow]
(
	[id_slideshow] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[img] Varchar(255) NULL,
	[text] Nvarchar(255) NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL,
	[id_admin] Integer NOT NULL
) 
go

Create table [Music]
(
	[id_music] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[id_musictype] Integer NOT NULL,
	[id_admin] Integer NOT NULL,
	[id_singer] Integer NOT NULL,
	[id_author] Integer NOT NULL,
	[name] Nvarchar(255) NULL,
	[publish_date] Smalldatetime NULL,
	[thumbnail] Varchar(255) NULL,
	[fille] Varchar(255) NULL,
	[lyric] Ntext NULL,
	[count_listened] Integer NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [Singer]
(
	[id_singer] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[name] Nvarchar(255) NULL,
	[sex] Bit NULL,
	[birthday] Smalldatetime NULL,
	[nationality] Nvarchar(255) NULL,
	[avatar] Varchar(255) NULL,
	[cover_img] Varchar(255) NULL,
	[history] Ntext NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [Author]
(
	[id_author] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[name] Nvarchar(255) NULL,
	[sex] Bit NULL,
	[birthday] Smalldatetime NULL,
	[nationality] Nvarchar(255) NULL,
	[avattar] Varchar(255) NULL,
	[cover_img] Varchar(255) NULL,
	[history] Ntext NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [MusicType]
(
	[id_musictype] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[name] Nvarchar(255) NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [Admin]
(
	[id_admin] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[username] Varchar(255) NULL,
	[password] Varchar(255) NULL,
	[name] Nvarchar(255) NULL,
	[email] Varchar(255) NULL,
	[phone] Varchar(11) NULL,
	[hide] Bit NULL,
	[link] Varchar(255) NULL
) 
go

Create table [PersonalPlayList]
(
	[id_playlist] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[id_user] Integer NOT NULL,
	[create_date] Smalldatetime NULL,
	[name] Nvarchar(255) NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [PersonalPlayList_Entry]
(
	[id_music] Integer NOT NULL,
	[id_playlist] Integer NOT NULL,
	[add_date] Smalldatetime NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL,
	primary key([id_music], [id_playlist])
) 
go

Create table [AdminPlayList]
(
	[id_playlist] Integer NOT NULL  PRIMARY KEY IDENTITY(1,1),
	[id_admin] Integer NOT NULL,
	[name] Nvarchar(255) NULL,
	[create_date] Smalldatetime NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [MV]
(
	[id_mv] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[id_singer] Integer NOT NULL,
	[name] Nvarchar(255) NULL,
	[publish_date] Smalldatetime NULL,
	[count_view] Integer NULL,
	[ytb_link] Varchar(255) NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [Blog]
(
	[id_blog] Integer NOT NULL PRIMARY KEY IDENTITY(1,1),
	[id_user] Integer NOT NULL,
	[titile] Nvarchar(255) NULL,
	[description] Nvarchar(500) NULL,
	[content] Ntext NULL,
	[img] Varchar(255) NULL,
	[write_date] Smalldatetime NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL
) 
go

Create table [AdminPlayList_Entry]
(
	[id_music] Integer NOT NULL,
	[id_playlist] Integer NOT NULL,
	[add_date] Smalldatetime NULL,
	[order] Integer NULL,
	[link] Varchar(255) NULL,
	[hide] Bit NULL,
	primary key([id_music], [id_playlist])
) 
go


Alter table [PersonalPlayList] add  foreign key([id_user]) references [User] ([id_user])  on update no action on delete no action 
go
Alter table [Blog] add  foreign key([id_user]) references [User] ([id_user])  on update no action on delete no action 
go
Alter table [PersonalPlayList_Entry] add  foreign key([id_music]) references [Music] ([id_music])  on update no action on delete no action 
go
Alter table [AdminPlayList_Entry] add  foreign key([id_music]) references [Music] ([id_music])  on update no action on delete no action 
go
Alter table [Music] add  foreign key([id_singer]) references [Singer] ([id_singer])  on update no action on delete no action 
go
Alter table [MV] add  foreign key([id_singer]) references [Singer] ([id_singer])  on update no action on delete no action 
go
Alter table [Music] add  foreign key([id_author]) references [Author] ([id_author])  on update no action on delete no action 
go
Alter table [Music] add  foreign key([id_musictype]) references [MusicType] ([id_musictype])  on update no action on delete no action 
go
Alter table [Music] add  foreign key([id_admin]) references [Admin] ([id_admin])  on update no action on delete no action 
go
Alter table [Menu] add  foreign key([id_admin]) references [Admin] ([id_admin])  on update no action on delete no action 
go
Alter table [SlideShow] add  foreign key([id_admin]) references [Admin] ([id_admin])  on update no action on delete no action 
go
Alter table [AdminPlayList] add  foreign key([id_admin]) references [Admin] ([id_admin])  on update no action on delete no action 
go
Alter table [PersonalPlayList_Entry] add  foreign key([id_playlist]) references [PersonalPlayList] ([id_playlist])  on update no action on delete no action 
go
Alter table [AdminPlayList_Entry] add  foreign key([id_playlist]) references [AdminPlayList] ([id_playlist])  on update no action on delete no action 

