/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2020/4/4 13:35:28                            */
/*==============================================================*/


drop table if exists DncIcon;

drop table if exists DncMenu;

drop table if exists DncPermission;

drop table if exists DncRole;

drop table if exists DncRolePermissionMapping;

drop table if exists DncUser;

drop table if exists DncUserRoleMapping;


/*==============================================================*/
/* Table: DncIcon                                               */
/*==============================================================*/
create table DncIcon
(
   Id                   int not null auto_increment,
   Code                 varchar(50) not null,
   Size                 varchar(20),
   Color                varchar(50),
   Custom               varchar(60),
   Description          varchar(500),
   Status               int not null,
   IsDeleted            int not null,
   CreatedOn            datetime not null,
   CreatedByUserGuid    varchar(50) not null,
   CreatedByUserName    varchar(50),
   ModifiedOn           datetime,
   ModifiedByUserGuid   varchar(50),
   ModifiedByUserName   varchar(50),
   primary key (Id)
)
;

/*==============================================================*/
/* Table: DncMenu                                               */
/*==============================================================*/
create table DncMenu
(
   Guid                 varchar(50) not null,
   Name                 varchar(50) not null,
   Url                  varchar(255),
   Alias                varchar(255),
   Icon                 varchar(255),
   ParentGuid           varchar(50),
   ParentName           varchar(50),
   Level                int not null,
   Description          varchar(800),
   Sort                 int not null,
   Status               int not null,
   IsDeleted            int not null,
   IsDefaultRouter      int not null,
   CreatedOn            datetime not null,
   CreatedByUserGuid    varchar(50) not null,
   CreatedByUserName    varchar(50),
   ModifiedOn           datetime,
   ModifiedByUserGuid   varchar(50),
   ModifiedByUserName   varchar(50),
   Component            varchar(255),
   HideInMenu           int,
   NotCache             int,
   BeforeCloseFun       varchar(255),
   primary key (Guid)
)
;

/*==============================================================*/
/* Table: DncPermission                                         */
/*==============================================================*/
create table DncPermission
(
   Code                 varchar(20) not null,
   MenuGuid             varchar(50) not null,
   Name                 varchar(50) not null,
   ActionCode           varchar(80) not null,
   Icon                 varchar(255),
   Description          varchar(500),
   Status               int not null,
   IsDeleted            int not null,
   Type                 int not null,
   CreatedByUserGuid    varchar(50) not null,
   CreatedOn            datetime not null,
   CreatedByUserName    varchar(50),
   ModifiedOn           datetime,
   ModifiedByUserGuid   varchar(50),
   ModifiedByUserName   varchar(50),
   primary key (Code)
)
;

/*==============================================================*/
/* Table: DncRole                                               */
/*==============================================================*/
create table DncRole
(
   Code                 varchar(50) not null,
   Name                 varchar(50) not null,
   Description          varchar(500),
   Status               int not null,
   IsDeleted            int not null,
   CreatedOn            datetime not null,
   CreatedByUserGuid    varchar(50) not null,
   CreatedByUserName    varchar(50),
   ModifiedOn           datetime,
   ModifiedByUserGuid   varchar(50),
   ModifiedByUserName   varchar(50),
   IsSuperAdministrator bit not null,
   IsBuiltin            bit not null,
   primary key (Code)
)
;

/*==============================================================*/
/* Table: DncRolePermissionMapping                              */
/*==============================================================*/
create table DncRolePermissionMapping
(
   RoleCode             varchar(50) not null,
   PermissionCode       varchar(20) not null,
   CreatedOn            datetime not null,
   primary key (RoleCode, PermissionCode)
)
;

/*==============================================================*/
/* Table: DncUser                                               */
/*==============================================================*/
create table DncUser
(
   Guid                 varchar(50) not null,
   LoginName            varchar(50) not null,
   DisplayName          varchar(50),
   Password             varchar(255),
   Avatar               varchar(255),
   UserType             int not null,
   IsLocked             int not null,
   Status               int not null,
   IsDeleted            int not null,
   CreatedOn            datetime not null,
   CreatedByUserGuid    varchar(50) not null,
   CreatedByUserName    varchar(50),
   ModifiedOn           datetime,
   ModifiedByUserGuid   varchar(50),
   ModifiedByUserName   varchar(50),
   Description          varchar(800),
   primary key (Guid)
)
;

/*==============================================================*/
/* Table: DncUserRoleMapping                                    */
/*==============================================================*/
create table DncUserRoleMapping
(
   UserGuid             varchar(50) not null,
   RoleCode             varchar(50) not null,
   CreatedOn            datetime not null,
   primary key (UserGuid, RoleCode)
)
;

alter table DncPermission add constraint FK_DncPermission_DncMenu_MenuGuid foreign key (MenuGuid)
      references DncMenu (Guid) on delete cascade;

alter table DncRolePermissionMapping add constraint FK_DncRolePermissionMapping_DncPermission_PermissionCode foreign key (PermissionCode)
      references DncPermission (Code);

alter table DncRolePermissionMapping add constraint FK_DncRolePermissionMapping_DncRole_RoleCode foreign key (RoleCode)
      references DncRole (Code);

alter table DncUserRoleMapping add constraint FK_DncUserRoleMapping_DncRole_RoleCode foreign key (RoleCode)
      references DncRole (Code);

alter table DncUserRoleMapping add constraint FK_DncUserRoleMapping_DncUser_UserGuid foreign key (UserGuid)
      references DncUser (Guid);

/*禁用索引*/	  
ALTER TABLE DncIcon DISABLE KEYS;
ALTER TABLE DncMenu DISABLE KEYS;
ALTER TABLE DncRole DISABLE KEYS;
ALTER TABLE DncUser DISABLE KEYS;
ALTER TABLE DncPermission DISABLE KEYS;
ALTER TABLE DncUserRoleMapping DISABLE KEYS;
ALTER TABLE DncRolePermissionMapping DISABLE KEYS;
/*来禁用外键约束*/
SET FOREIGN_KEY_CHECKS=0;

/*启用索引*/ 
ALTER TABLE DncIcon ENABLE KEYS;
ALTER TABLE DncMenu ENABLE KEYS;
ALTER TABLE DncRole ENABLE KEYS;
ALTER TABLE DncUser ENABLE KEYS;
ALTER TABLE DncPermission ENABLE KEYS;
ALTER TABLE DncUserRoleMapping ENABLE KEYS;
ALTER TABLE DncRolePermissionMapping ENABLE KEYS
/*启用外键约束.*/
 SET FOREIGN_KEY_CHECKS=1;


