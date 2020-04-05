/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2020/4/5 19:38:43                            */
/*==============================================================*/

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_admin_log')
            and   type = 'U')
   drop table dbo.sys_admin_log
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_area')
            and   type = 'U')
   drop table dbo.sys_area
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.sys_article')
            and   name  = 'created_at'
            and   indid > 0
            and   indid < 255)
   drop index dbo.sys_article.created_at
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_article')
            and   type = 'U')
   drop table dbo.sys_article
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.sys_category')
            and   name  = 'weigh'
            and   indid > 0
            and   indid < 255)
   drop index dbo.sys_category.weigh
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.sys_category')
            and   name  = 'pid'
            and   indid > 0
            and   indid < 255)
   drop index dbo.sys_category.pid
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_category')
            and   type = 'U')
   drop table dbo.sys_category
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sys_config')
            and   type = 'U')
   drop table sys_config
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_configs')
            and   type = 'U')
   drop table dbo.sys_configs
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_dept')
            and   type = 'U')
   drop table dbo.sys_dept
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_dict_data')
            and   type = 'U')
   drop table dbo.sys_dict_data
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_dict_type')
            and   type = 'U')
   drop table dbo.sys_dict_type
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_menu')
            and   type = 'U')
   drop table dbo.sys_menu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_post')
            and   type = 'U')
   drop table dbo.sys_post
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_role')
            and   type = 'U')
   drop table dbo.sys_role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_role_dept')
            and   type = 'U')
   drop table dbo.sys_role_dept
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_role_menu')
            and   type = 'U')
   drop table dbo.sys_role_menu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_user')
            and   type = 'U')
   drop table dbo.sys_user
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_user_post')
            and   type = 'U')
   drop table dbo.sys_user_post
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_user_role')
            and   type = 'U')
   drop table dbo.sys_user_role
go

/*==============================================================*/
/* Table: sys_admin_log                                         */
/*==============================================================*/
create table dbo.sys_admin_log (
   id                   bigint               identity,
   route                varchar(255)         not null,
   method               varchar(255)         not null,
   description          text                 null,
   user_id              int                  not null default 0,
   ip                   varchar(20)          not null default '0',
   created_at           int                  not null default 0,
   updated_at           int                  not null,
   deleted_at           timestamp            not null,
   constraint PK_sys_admin_log primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_admin_log') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_admin_log' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '��̨�û���־', 
   'user', 'dbo', 'table', 'sys_admin_log'
go

/*==============================================================*/
/* Table: sys_area                                              */
/*==============================================================*/
create table dbo.sys_area (
   id                   bigint               identity,
   adcode               varchar(20)          null,
   citycode             int                  not null,
   center               varchar(500)         null,
   name                 varchar(100)         null,
   parent_id            int                  not null,
   is_end              bit           null default '1',
   constraint PK_sys_area primary key nonclustered (id),
   constraint adcode unique (adcode)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_area') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_area' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '������Ϣ', 
   'user', 'dbo', 'table', 'sys_area'
go

/*==============================================================*/
/* Table: sys_article                                           */
/*==============================================================*/
create table dbo.sys_article (
   id                   bigint               identity,
   category_id          int                  not null default 0,
   post_title           varchar(100)         not null,
   author               varchar(255)         not null,
   post_status          tinyint              not null default 1,
   comment_status       tinyint              not null default 1,
   flag                 tinyint              not null default 0,
   post_hits            bigint               not null default 0,
   post_favorites       int                  not null default 0,
   post_like            bigint               not null default 0,
   comment_count        bigint               not null default 0,
   post_keywords        varchar(150)         not null,
   post_excerpt         varchar(500)         not null,
   post_source          varchar(150)         not null,
   image                varchar(100)         not null,
   post_content         text                 null,
   created_at           int                  not null default 0,
   updated_at           int                  not null default 0,
   constraint PK_sys_article primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_article') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_article' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '���±�', 
   'user', 'dbo', 'table', 'sys_article'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'id'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', 'dbo', 'table', 'sys_article', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'category_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'category_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��Ŀid',
   'user', 'dbo', 'table', 'sys_article', 'column', 'category_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_title')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_title'

end


execute sp_addextendedproperty 'MS_Description', 
   'post����',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_title'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'author')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'author'

end


execute sp_addextendedproperty 'MS_Description', 
   '�������û�id',
   'user', 'dbo', 'table', 'sys_article', 'column', 'author'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_status'

end


execute sp_addextendedproperty 'MS_Description', 
   '״̬;1:�ѷ���;0:δ����;',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'comment_status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'comment_status'

end


execute sp_addextendedproperty 'MS_Description', 
   '����״̬;1:����;0:������',
   'user', 'dbo', 'table', 'sys_article', 'column', 'comment_status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'flag')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'flag'

end


execute sp_addextendedproperty 'MS_Description', 
   '1���ţ�2��ҳ��3�Ƽ�',
   'user', 'dbo', 'table', 'sys_article', 'column', 'flag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_hits')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_hits'

end


execute sp_addextendedproperty 'MS_Description', 
   '�鿴��',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_hits'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_favorites')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_favorites'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ղ���',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_favorites'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_like')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_like'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_like'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'comment_count')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'comment_count'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_article', 'column', 'comment_count'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_keywords')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_keywords'

end


execute sp_addextendedproperty 'MS_Description', 
   'seo keywords',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_keywords'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_excerpt')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_excerpt'

end


execute sp_addextendedproperty 'MS_Description', 
   'postժҪ',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_excerpt'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_source')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_source'

end


execute sp_addextendedproperty 'MS_Description', 
   'ת�����µ���Դ',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_source'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'image')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'image'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ͼ',
   'user', 'dbo', 'table', 'sys_article', 'column', 'image'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_content')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_content'

end


execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'sys_article', 'column', 'post_content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_article', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_article', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_article', 'column', 'updated_at'
go

/*==============================================================*/
/* Index: created_at                                            */
/*==============================================================*/
create index created_at on dbo.sys_article (
created_at ASC
)
go

/*==============================================================*/
/* Table: sys_category                                          */
/*==============================================================*/
create table dbo.sys_category (
   id                   int                  identity,
   pid                  int                  not null default 0,
   type                 tinyint              not null default 1,
   name                 varchar(30)          not null,
   nickname             varchar(50)          not null,
   flag                 tinyint              not null default 0,
   href                 varchar(255)         not null,
   is_nav               tinyint              not null default 0,
   image                varchar(100)         not null,
   keywords             varchar(255)         not null,
   description          varchar(255)         not null,
   content              text                 not null,
   created_at           int                  not null,
   updated_at           int                  not null,
   deleted_at           timestamp            not null,
   weigh                int                  not null default 0,
   status               tinyint              not null default 1,
   tpl                  varchar(255)         not null default 'list',
   constraint PK_sys_category primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_category') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_category' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�����', 
   'user', 'dbo', 'table', 'sys_category'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'pid')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'pid'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ID',
   'user', 'dbo', 'table', 'sys_category', 'column', 'pid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'type'

end


execute sp_addextendedproperty 'MS_Description', 
   '��Ŀ����',
   'user', 'dbo', 'table', 'sys_category', 'column', 'type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'name'

end


execute sp_addextendedproperty 'MS_Description', 
   '��Ŀ����',
   'user', 'dbo', 'table', 'sys_category', 'column', 'name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'nickname')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'nickname'

end


execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_category', 'column', 'nickname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'flag')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'flag'

end


execute sp_addextendedproperty 'MS_Description', 
   '0,1��,2��ҳ,3�Ƽ�',
   'user', 'dbo', 'table', 'sys_category', 'column', 'flag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'href')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'href'

end


execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_category', 'column', 'href'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'is_nav')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'is_nav'

end


execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ��ǵ���',
   'user', 'dbo', 'table', 'sys_category', 'column', 'is_nav'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'image')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'image'

end


execute sp_addextendedproperty 'MS_Description', 
   'ͼƬ',
   'user', 'dbo', 'table', 'sys_category', 'column', 'image'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'keywords')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'keywords'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ؼ���',
   'user', 'dbo', 'table', 'sys_category', 'column', 'keywords'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'description')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'description'

end


execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_category', 'column', 'description'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'content')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'content'

end


execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_category', 'column', 'content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_category', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_category', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'deleted_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'deleted_at'

end


execute sp_addextendedproperty 'MS_Description', 
   'ɾ��ʱ��',
   'user', 'dbo', 'table', 'sys_category', 'column', 'deleted_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'weigh')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'weigh'

end


execute sp_addextendedproperty 'MS_Description', 
   'Ȩ��',
   'user', 'dbo', 'table', 'sys_category', 'column', 'weigh'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'status'

end


execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', 'dbo', 'table', 'sys_category', 'column', 'status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'tpl')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_category', 'column', 'tpl'

end


execute sp_addextendedproperty 'MS_Description', 
   'ģ���ļ�',
   'user', 'dbo', 'table', 'sys_category', 'column', 'tpl'
go

/*==============================================================*/
/* Index: pid                                                   */
/*==============================================================*/
create index pid on dbo.sys_category (
pid ASC
)
go

/*==============================================================*/
/* Index: weigh                                                 */
/*==============================================================*/
create index weigh on dbo.sys_category (
 weigh ASC
)
go



/*==============================================================*/
/* Table: sys_configs                                           */
/*==============================================================*/
create table dbo.sys_configs (
   id                   int                  identity,
   config_name          varchar(100)         null,
   config_key           varchar(100)         null,
   config_value         varchar(100)         null,
   config_type         bit           null default '1',
   created_by           int                  null,
   updated_by           int                  null,
   created_at           int                  null,
   updated_at           int                  null,
   deleted_at           timestamp            null,
   remark               varchar(500)         null,
   constraint PK_sys_configs primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_configs') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_configs' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�������ñ�', 
   'user', 'dbo', 'table', 'sys_configs'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'config_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'config_key')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_key'

end


execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_key'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'config_value')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_value'

end


execute sp_addextendedproperty 'MS_Description', 
   '������ֵ',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_value'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'config_type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_type'

end


execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ���ã�1�� 2��',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'config_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'created_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'created_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'updated_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'updated_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'deleted_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'deleted_at'

end


execute sp_addextendedproperty 'MS_Description', 
   'ɾ��ʱ��',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'deleted_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_configs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_configs', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_configs', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_dept                                              */
/*==============================================================*/
create table dbo.sys_dept (
   id                   int                  identity,
   parent_id            int                  null default 0,
   ancestors            varchar(50)          null,
   dept_name            varchar(30)          null,
   order_num            int                  null default 0,
   leader               varchar(20)          null,
   phone                varchar(11)          null,
   email                varchar(50)          null,
   status               char(1)              null default '0',
   del_flag             char(1)              null default '0',
   create_by            varchar(64)          null,
   created_at           int                  null,
   update_by            varchar(64)          null,
   updated_at           int                  null,
   remark               varchar(500)         null,
   constraint PK_sys_dept primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_dept') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_dept' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '���ű�', 
   'user', 'dbo', 'table', 'sys_dept'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'id'

end


execute sp_addextendedproperty 'MS_Description', 
   '����id',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'parent_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'parent_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '������id',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'parent_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ancestors')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'ancestors'

end


execute sp_addextendedproperty 'MS_Description', 
   '�漶�б�',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'ancestors'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dept_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'dept_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'dept_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'order_num')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'order_num'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ʾ˳��',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'order_num'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'leader')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'leader'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'leader'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'phone')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'phone'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ϵ�绰',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'phone'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'email')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'email'

end


execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'status'

end


execute sp_addextendedproperty 'MS_Description', 
   '����״̬��0���� 1ͣ�ã�',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'del_flag')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'del_flag'

end


execute sp_addextendedproperty 'MS_Description', 
   'ɾ����־��0������� 2����ɾ����',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'del_flag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'create_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'create_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'update_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'update_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'update_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dept', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_dept', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_dict_data                                         */
/*==============================================================*/
create table dbo.sys_dict_data (
   dict_code            int                  not null,
   id                   int                  identity,
   dict_sort            int                  null default 0,
   dict_label           varchar(100)         null,
   dict_value           varchar(100)         null,
   dict_type            varchar(100)         null,
   css_class            varchar(100)         null,
   list_class           varchar(100)         null,
   is_default           char(1)              NULL DEFAULT('N'),
   status               char(1)              null default '0',
   create_by            varchar(64)          null,
   created_at           int                  null,
   update_by            varchar(64)          null,
   updated_at           int                  null,
   remark               varchar(500)         null,
   constraint PK_sys_dict_data primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_dict_data') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_dict_data' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�ֵ����ݱ�', 
   'user', 'dbo', 'table', 'sys_dict_data'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_code')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_code'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_code'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_sort')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_sort'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֵ�����',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_label')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_label'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֵ��ǩ',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_label'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_value')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_value'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֵ��ֵ',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_value'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_type'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֵ�����',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'dict_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'css_class')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'css_class'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ʽ���ԣ�������ʽ��չ��',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'css_class'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'list_class')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'list_class'

end


execute sp_addextendedproperty 'MS_Description', 
   '��������ʽ',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'list_class'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'is_default')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'is_default'

end


execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�Ĭ�ϣ�Y�� N��',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'is_default'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'status'

end


execute sp_addextendedproperty 'MS_Description', 
   '״̬��0���� 1ͣ�ã�',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'create_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'create_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'update_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'update_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'update_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_data')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_dict_data', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_dict_type                                         */
/*==============================================================*/
create table dbo.sys_dict_type (
   id                   int                  identity,
   dict_id              int                  not null,
   dict_name            varchar(100)         null,
   dict_type            varchar(100)         null,
   status               char(1)              null default '0',
   create_by            varchar(64)          null,
   created_at           int                  null,
   update_by            varchar(64)          null,
   updated_at           int                  null,
   remark               varchar(500)         null,
   constraint PK_sys_dict_type primary key nonclustered (id),
   constraint dict_type unique (dict_type)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_dict_type') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_dict_type' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�ֵ����ͱ�', 
   'user', 'dbo', 'table', 'sys_dict_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'dict_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֵ�����',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'dict_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'dict_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֵ�����',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'dict_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dict_type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'dict_type'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֵ�����',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'dict_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'status'

end


execute sp_addextendedproperty 'MS_Description', 
   '״̬��0���� 1ͣ�ã�',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'create_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'create_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'update_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'update_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'update_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_dict_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_dict_type', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_menu                                              */
/*==============================================================*/
create table dbo.sys_menu (
   id                   int                  identity,
   menu_name            varchar(50)          not null,
   parent_id            int                  null default 0,
   order_num            int                  null default 0,
   url                  varchar(200)         null  default ('#'),
   menu_type            tinyint              null,
   visible              char(1)              null default '0',
   perms                varchar(100)         null,
   icon                 varchar(100)         null  default ('#'),
   create_by            varchar(64)          null,
   created_at           int                  null,
   update_by            varchar(64)          null,
   updated_at           int                  null,
   remark               varchar(500)         null,
   constraint PK_sys_menu primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_menu') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_menu' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�˵�Ȩ�ޱ�', 
   'user', 'dbo', 'table', 'sys_menu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'id'

end


execute sp_addextendedproperty 'MS_Description', 
   '�˵�ID',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'menu_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '�˵�����',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'menu_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'parent_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'parent_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '���˵�ID',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'parent_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'order_num')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'order_num'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ʾ˳��',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'order_num'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'url')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'url'

end


execute sp_addextendedproperty 'MS_Description', 
   '�����ַ',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'menu_type'

end


execute sp_addextendedproperty 'MS_Description', 
   '�˵����ͣ�1,Ŀ¼ 2,�˵� 3,��ť��',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'menu_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'visible')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'visible'

end


execute sp_addextendedproperty 'MS_Description', 
   '�˵�״̬��0��ʾ 1���أ�',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'visible'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'perms')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'perms'

end


execute sp_addextendedproperty 'MS_Description', 
   'Ȩ�ޱ�ʶ',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'perms'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'icon')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'icon'

end


execute sp_addextendedproperty 'MS_Description', 
   '�˵�ͼ��',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'icon'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'create_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'create_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'update_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'update_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'update_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_menu', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_menu', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_post                                              */
/*==============================================================*/
create table dbo.sys_post (
   id                   int                  identity,
   post_code            varchar(64)          not null,
   post_name            varchar(50)          not null,
   post_sort            int                  not null,
   status               char(1)              not null,
   create_by            varchar(64)          null,
   created_at           int                  null,
   update_by            varchar(64)          null,
   updated_at           int                  null,
   remark               varchar(500)         null,
   constraint PK_sys_post primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_post') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_post' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '��λ��Ϣ��', 
   'user', 'dbo', 'table', 'sys_post'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��λID',
   'user', 'dbo', 'table', 'sys_post', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_code')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'post_code'

end


execute sp_addextendedproperty 'MS_Description', 
   '��λ����',
   'user', 'dbo', 'table', 'sys_post', 'column', 'post_code'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'post_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '��λ����',
   'user', 'dbo', 'table', 'sys_post', 'column', 'post_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_sort')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'post_sort'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ʾ˳��',
   'user', 'dbo', 'table', 'sys_post', 'column', 'post_sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'status'

end


execute sp_addextendedproperty 'MS_Description', 
   '״̬��0���� 1ͣ�ã�',
   'user', 'dbo', 'table', 'sys_post', 'column', 'status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'create_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_post', 'column', 'create_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_post', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'update_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'update_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_post', 'column', 'update_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_post', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_post', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_post', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_role                                              */
/*==============================================================*/
create table dbo.sys_role (
   id                   int                  identity,
   role_name            varchar(30)          not null,
   role_key             varchar(100)         not null,
   role_sort            int                  not null,
   data_scope           char(1)              null default '1',
   status               char(1)              not null,
   del_flag             char(1)              null default '0',
   create_by            varchar(64)          null,
   created_at           int                  null,
   update_by            varchar(64)          null,
   updated_at           int                  null,
   remark               varchar(500)         null,
   constraint PK_sys_role primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_role') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_role' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '��ɫ��Ϣ��', 
   'user', 'dbo', 'table', 'sys_role'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ɫID',
   'user', 'dbo', 'table', 'sys_role', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'role_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ɫ����',
   'user', 'dbo', 'table', 'sys_role', 'column', 'role_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_key')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'role_key'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ɫȨ���ַ���',
   'user', 'dbo', 'table', 'sys_role', 'column', 'role_key'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_sort')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'role_sort'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ʾ˳��',
   'user', 'dbo', 'table', 'sys_role', 'column', 'role_sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'data_scope')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'data_scope'

end


execute sp_addextendedproperty 'MS_Description', 
   '���ݷ�Χ��1��ȫ������Ȩ�� 2���Զ�����Ȩ�ޣ�',
   'user', 'dbo', 'table', 'sys_role', 'column', 'data_scope'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'status'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ɫ״̬��0���� 1ͣ�ã�',
   'user', 'dbo', 'table', 'sys_role', 'column', 'status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'del_flag')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'del_flag'

end


execute sp_addextendedproperty 'MS_Description', 
   'ɾ����־��0������� 2����ɾ����',
   'user', 'dbo', 'table', 'sys_role', 'column', 'del_flag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'create_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_role', 'column', 'create_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_role', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'update_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'update_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_role', 'column', 'update_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_role', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_role', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_role_dept                                         */
/*==============================================================*/
create table dbo.sys_role_dept (
   role_id              int                  not null,
   dept_id              int                  not null,
   id                   int                  identity,
   constraint PK_sys_role_dept primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_role_dept') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_role_dept' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '��ɫ�Ͳ��Ź�����', 
   'user', 'dbo', 'table', 'sys_role_dept'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role_dept', 'column', 'role_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ɫID',
   'user', 'dbo', 'table', 'sys_role_dept', 'column', 'role_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role_dept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'dept_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role_dept', 'column', 'dept_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', 'dbo', 'table', 'sys_role_dept', 'column', 'dept_id'
go

/*==============================================================*/
/* Table: sys_role_menu                                         */
/*==============================================================*/
create table dbo.sys_role_menu (
   role_id              int                  not null,
   menu_id              int                  not null,
   id                   int                  identity,
   constraint PK_sys_role_menu primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_role_menu') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_role_menu' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '��ɫ�Ͳ˵�������', 
   'user', 'dbo', 'table', 'sys_role_menu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role_menu', 'column', 'role_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ɫID',
   'user', 'dbo', 'table', 'sys_role_menu', 'column', 'role_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_role_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_role_menu', 'column', 'menu_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '�˵�ID',
   'user', 'dbo', 'table', 'sys_role_menu', 'column', 'menu_id'
go

/*==============================================================*/
/* Table: sys_user                                              */
/*==============================================================*/
create table dbo.sys_user (
   id                   int                  identity,
   login_name           varchar(30)          not null,
   user_name            varchar(30)          not null,
   user_type            tinyint              null default 1,
   email                varchar(50)          null,
   phone                varchar(12)          null,
   phonenumber          varchar(11)          null,
   sex                 bit           null default '1',
   avatar               varchar(100)         null,
   password             varchar(50)          null,
   salt                 varchar(20)          null,
   status              bit           null default '1',
   del_flag             tinyint              null default 1,
   login_ip             varchar(50)          null,
   login_date           int                  null,
   create_by            varchar(64)          null,
   created_at           int                  null,
   update_by            varchar(64)          null,
   updated_at           int                  null,
   deleted_at           timestamp            null,
   remark               varchar(500)         null,
   constraint PK_sys_user primary key nonclustered (id),
   constraint email unique (email),
   constraint phone unique (phone),
   constraint user_name unique (user_name)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_user') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_user' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�û���Ϣ��', 
   'user', 'dbo', 'table', 'sys_user'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'id'

end


execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', 'dbo', 'table', 'sys_user', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'login_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'login_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '��¼�˺�',
   'user', 'dbo', 'table', 'sys_user', 'column', 'login_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'user_name'

end


execute sp_addextendedproperty 'MS_Description', 
   '�û��ǳ�',
   'user', 'dbo', 'table', 'sys_user', 'column', 'user_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'user_type'

end


execute sp_addextendedproperty 'MS_Description', 
   '�û����ͣ�1ϵͳ�û���',
   'user', 'dbo', 'table', 'sys_user', 'column', 'user_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'email')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'email'

end


execute sp_addextendedproperty 'MS_Description', 
   '�û�����',
   'user', 'dbo', 'table', 'sys_user', 'column', 'email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'phone')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'phone'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֻ���',
   'user', 'dbo', 'table', 'sys_user', 'column', 'phone'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'phonenumber')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'phonenumber'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ֻ�����',
   'user', 'dbo', 'table', 'sys_user', 'column', 'phonenumber'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'sex')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'sex'

end


execute sp_addextendedproperty 'MS_Description', 
   '�û��Ա�1�� 2Ů 3δ֪��',
   'user', 'dbo', 'table', 'sys_user', 'column', 'sex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'avatar')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'avatar'

end


execute sp_addextendedproperty 'MS_Description', 
   'ͷ��·��',
   'user', 'dbo', 'table', 'sys_user', 'column', 'avatar'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'password')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'password'

end


execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_user', 'column', 'password'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'salt')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'salt'

end


execute sp_addextendedproperty 'MS_Description', 
   '�μ���',
   'user', 'dbo', 'table', 'sys_user', 'column', 'salt'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'status'

end


execute sp_addextendedproperty 'MS_Description', 
   '�ʺ�״̬��1���� 2���ã�',
   'user', 'dbo', 'table', 'sys_user', 'column', 'status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'del_flag')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'del_flag'

end


execute sp_addextendedproperty 'MS_Description', 
   'ɾ����־��1������� 2����ɾ����',
   'user', 'dbo', 'table', 'sys_user', 'column', 'del_flag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'login_ip')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'login_ip'

end


execute sp_addextendedproperty 'MS_Description', 
   '����½IP',
   'user', 'dbo', 'table', 'sys_user', 'column', 'login_ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'login_date')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'login_date'

end


execute sp_addextendedproperty 'MS_Description', 
   '����½ʱ��',
   'user', 'dbo', 'table', 'sys_user', 'column', 'login_date'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'create_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_user', 'column', 'create_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'created_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'created_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_user', 'column', 'created_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'update_by')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'update_by'

end


execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'sys_user', 'column', 'update_by'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'updated_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'updated_at'

end


execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_user', 'column', 'updated_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'deleted_at')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'deleted_at'

end


execute sp_addextendedproperty 'MS_Description', 
   'ɾ��ʱ��',
   'user', 'dbo', 'table', 'sys_user', 'column', 'deleted_at'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'remark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user', 'column', 'remark'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'sys_user', 'column', 'remark'
go

/*==============================================================*/
/* Table: sys_user_post                                         */
/*==============================================================*/
create table dbo.sys_user_post (
   user_id              int                  not null,
   post_id              int                  not null,
   id                   int                  identity,
   constraint PK_sys_user_post primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_user_post') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_user_post' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�û����λ������', 
   'user', 'dbo', 'table', 'sys_user_post'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user_post', 'column', 'user_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', 'dbo', 'table', 'sys_user_post', 'column', 'user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user_post')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'post_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user_post', 'column', 'post_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��λID',
   'user', 'dbo', 'table', 'sys_user_post', 'column', 'post_id'
go

/*==============================================================*/
/* Table: sys_user_role                                         */
/*==============================================================*/
create table dbo.sys_user_role (
   user_id              int                  not null,
   role_id              int                  not null,
   id                   int                  identity,
   constraint PK_sys_user_role primary key nonclustered (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.sys_user_role') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'sys_user_role' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '�û��ͽ�ɫ������', 
   'user', 'dbo', 'table', 'sys_user_role'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user_role', 'column', 'user_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '�û�ID',
   'user', 'dbo', 'table', 'sys_user_role', 'column', 'user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.sys_user_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'sys_user_role', 'column', 'role_id'

end


execute sp_addextendedproperty 'MS_Description', 
   '��ɫID',
   'user', 'dbo', 'table', 'sys_user_role', 'column', 'role_id'
go




/*==============================================================*/
/* User: D2Cms                                                  */
/*==============================================================*/
/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
