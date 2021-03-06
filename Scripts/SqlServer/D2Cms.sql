USE [D2Cms]
GO
/****** Object:  Table [sys_admin_log]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_admin_log](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[route] [varchar](255) NOT NULL,
	[method] [varchar](255) NOT NULL,
	[description] [text] NULL,
	[user_id] [int] NOT NULL,
	[ip] [varchar](20) NOT NULL,
	[created_at] [int] NOT NULL,
	[updated_at] [int] NOT NULL,
	[deleted_at] [timestamp] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sys_area]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_area](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[adcode] [varchar](20) NULL,
	[citycode] [int] NOT NULL,
	[center] [varchar](500) NULL,
	[name] [varchar](100) NULL,
	[parent_id] [int] NOT NULL,
	[is_end] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [sys_article]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_article](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NOT NULL,
	[post_title] [varchar](100) NOT NULL,
	[author] [varchar](255) NOT NULL,
	[post_status] [tinyint] NOT NULL,
	[comment_status] [tinyint] NOT NULL,
	[flag] [tinyint] NOT NULL,
	[post_hits] [bigint] NOT NULL,
	[post_favorites] [int] NOT NULL,
	[post_like] [bigint] NOT NULL,
	[comment_count] [bigint] NOT NULL,
	[post_keywords] [varchar](150) NOT NULL,
	[post_excerpt] [varchar](500) NOT NULL,
	[post_source] [varchar](150) NOT NULL,
	[image] [varchar](100) NOT NULL,
	[post_content] [text] NULL,
	[created_at] [int] NOT NULL,
	[updated_at] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sys_category]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NOT NULL,
	[type] [tinyint] NOT NULL,
	[name] [varchar](30) NOT NULL,
	[nickname] [varchar](50) NOT NULL,
	[flag] [tinyint] NOT NULL,
	[href] [varchar](255) NOT NULL,
	[is_nav] [tinyint] NOT NULL,
	[image] [varchar](100) NOT NULL,
	[keywords] [varchar](255) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[content] [text] NOT NULL,
	[created_at] [int] NOT NULL,
	[updated_at] [int] NOT NULL,
	[deleted_at] [timestamp] NOT NULL,
	[weigh] [int] NOT NULL,
	[status] [tinyint] NOT NULL,
	[tpl] [varchar](255) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sys_configs]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_configs](
	[id] [int] NOT NULL,
	[config_name] [varchar](100) NULL,
	[config_key] [varchar](100) NULL,
	[config_value] [varchar](100) NULL,
	[config_type] [tinyint] NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[created_at] [int] NULL,
	[updated_at] [int] NULL,
	[deleted_at] [datetime] NULL,
	[remark] [varchar](500) NULL,
 CONSTRAINT [PK_sys_configs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sys_dept]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_dept](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[ancestors] [varchar](50) NULL,
	[dept_name] [varchar](30) NULL,
	[order_num] [int] NULL,
	[leader] [varchar](20) NULL,
	[phone] [varchar](11) NULL,
	[email] [varchar](50) NULL,
	[status] [char](1) NULL,
	[del_flag] [char](1) NULL,
	[create_by] [varchar](64) NULL,
	[created_at] [int] NULL,
	[update_by] [varchar](64) NULL,
	[updated_at] [int] NULL,
	[remark] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [sys_dict_data]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_dict_data](
	[id] [int] NOT NULL,
	[dict_code] [int] NOT NULL,
	[dict_sort] [int] NULL,
	[dict_label] [varchar](100) NULL,
	[dict_value] [varchar](100) NULL,
	[dict_type] [varchar](100) NULL,
	[css_class] [varchar](100) NULL,
	[list_class] [varchar](100) NULL,
	[is_default] [char](1) NULL,
	[status] [char](1) NULL,
	[create_by] [varchar](64) NULL,
	[created_at] [int] NULL,
	[update_by] [varchar](64) NULL,
	[updated_at] [int] NULL,
	[remark] [varchar](500) NULL,
 CONSTRAINT [PK_sys_dict_data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sys_dict_type]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_dict_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dict_id] [int] NOT NULL,
	[dict_name] [varchar](100) NULL,
	[dict_type] [varchar](100) NULL,
	[status] [char](1) NULL,
	[create_by] [varchar](64) NULL,
	[created_at] [int] NULL,
	[update_by] [varchar](64) NULL,
	[updated_at] [int] NULL,
	[remark] [varchar](500) NULL,
 CONSTRAINT [PK_sys_dict_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sys_menu]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu_name] [varchar](50) NOT NULL,
	[parent_id] [int] NULL,
	[order_num] [int] NULL,
	[url] [varchar](200) NULL,
	[menu_type] [tinyint] NULL,
	[visible] [tinyint] NULL,
	[perms] [varchar](100) NULL,
	[icon] [varchar](100) NULL,
	[create_by] [varchar](64) NULL,
	[created_at] [int] NULL,
	[update_by] [varchar](64) NULL,
	[updated_at] [int] NULL,
	[remark] [varchar](500) NULL,
 CONSTRAINT [PK_sys_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sys_post]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[post_code] [varchar](64) NOT NULL,
	[post_name] [varchar](50) NOT NULL,
	[post_sort] [int] NOT NULL,
	[status] [char](1) NOT NULL,
	[create_by] [varchar](64) NULL,
	[created_at] [int] NULL,
	[update_by] [varchar](64) NULL,
	[updated_at] [int] NULL,
	[remark] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [sys_role]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_role](
	[id] [int] NOT NULL,
	[role_name] [varchar](30) NOT NULL,
	[role_key] [varchar](100) NOT NULL,
	[role_sort] [int] NOT NULL,
	[data_scope] [tinyint] NULL,
	[status] [tinyint] NOT NULL,
	[del_flag] [tinyint] NULL,
	[create_by] [varchar](64) NULL,
	[created_at] [int] NULL,
	[update_by] [varchar](64) NULL,
	[updated_at] [int] NULL,
	[remark] [varchar](500) NULL,
 CONSTRAINT [PK_sys_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sys_role_dept]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_role_dept](
	[role_id] [int] NOT NULL,
	[dept_id] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [sys_role_menu]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_role_menu](
	[role_id] [int] NOT NULL,
	[menu_id] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [sys_user]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login_name] [varchar](30) NOT NULL,
	[user_name] [varchar](30) NOT NULL,
	[user_type] [tinyint] NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](12) NULL,
	[phonenumber] [varchar](11) NULL,
	[sex] [tinyint] NULL,
	[avatar] [varchar](100) NULL,
	[password] [varchar](50) NULL,
	[salt] [varchar](20) NULL,
	[status] [tinyint] NULL,
	[del_flag] [tinyint] NULL,
	[login_ip] [varchar](50) NULL,
	[login_date] [int] NULL,
	[create_by] [varchar](64) NULL,
	[created_at] [int] NULL,
	[update_by] [varchar](64) NULL,
	[updated_at] [int] NULL,
	[deleted_at] [datetime] NULL,
	[remark] [varchar](500) NULL,
 CONSTRAINT [PK_sys_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sys_user_post]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_user_post](
	[user_id] [int] NOT NULL,
	[post_id] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [sys_user_role]    Script Date: 2020/4/8 23:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_user_role](
	[user_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
INSERT [sys_configs] ([id], [config_name], [config_key], [config_value], [config_type], [created_by], [updated_by], [created_at], [updated_at], [deleted_at], [remark]) VALUES (1, N'用户管理 - 账号初始密码', N'sys.user.initPassword', N'123456', 1, 0, 0, 2006054656, 1576995642, NULL, N'初始化密码 123456')
SET IDENTITY_INSERT [sys_dept] ON 

INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (1, 0, N'', N'公司', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (2, 1, N'', N'研发', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (3, 1, N'', N'项目', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (4, 1, N'', N'测试', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (5, 2, N'', N'研发组 1', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (6, 2, N'', N'研发组 2', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (7, 4, N'', N'测试 1', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (8, 2, N'', N'研发组 3', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (10, 0, N'', N'外部用户', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (11, 10, N'', N'业务员', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
INSERT [sys_dept] ([id], [parent_id], [ancestors], [dept_name], [order_num], [leader], [phone], [email], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (12, 10, N'', N'销售', 0, N'', N'', N'', N' ', N' ', N'', 2006054656, N'', 2006054656, N'')
SET IDENTITY_INSERT [sys_dept] OFF
INSERT [sys_dict_data] ([id], [dict_code], [dict_sort], [dict_label], [dict_value], [dict_type], [css_class], [list_class], [is_default], [status], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (1, 0, 1, N'禁用', N'', N'status', N'', N'', N'1', N'1', N'77', 1573661421, N'0', 1573661421, N'')
INSERT [sys_dict_data] ([id], [dict_code], [dict_sort], [dict_label], [dict_value], [dict_type], [css_class], [list_class], [is_default], [status], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (2, 0, 1, N'激活', N'', N'status', N'', N'', N'1', N'1', N'77', 1573661239, N'0', 1573661239, N'')
SET IDENTITY_INSERT [sys_menu] ON 

INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (53, N'系统管理', 0, 1, N'', 1, 1, N'', N'cog', N'0', 1571810848, N'81', 1582277057, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (81, N'菜单管理', 53, 3, N'/management/menu', 1, 1, N'', N'navicon', N'0', 1571927217, N'1', 1576927321, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (85, N'角色管理', 53, 2, N'/management/role', 1, 1, N'', N'users', N'0', 1571933107, N'1', 1576927328, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (88, N'字典管理', 53, 6, N'/management/dict', 1, 1, N'', N'book', N'0', 1571933136, N'1', 1577011803, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (94, N'参数设置', 53, 8, N'/management/config', 1, 1, N'', N'cubes', N'0', 1572265564, N'1', 1577011827, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (111, N'用户管理', 53, 1, N'/management/user', 1, 1, N'', N'user-circle', N'77', 1575898102, N'1', 1577178402, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (112, N'部门管理', 53, 4, N'/management/dept', 1, 1, N'', N'bank', N'77', 1575939112, N'1', 1577011781, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (113, N'岗位管理', 53, 5, N'/management/post', 1, 1, N'', N'briefcase', N'77', 1575939147, N'1', 1577011796, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (115, N'字典数据', 53, 7, N'/management/dict-data', 1, 2, N'', N'', N'1', 1576995475, N'1', 1577011814, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (116, N'菜单查询', 81, 0, N'', 2, 1, N'system:menu:query', N'', N'1', 1577004934, N'1', 1577008670, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (117, N'菜单新增', 81, 0, N'', 2, 1, N'system:menu:add', N'', N'1', 1577008738, N'0', 1577008738, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (118, N'菜单修改', 81, 0, N'', 2, 1, N'system:menu:edit', N'', N'1', 1577008759, N'0', 1577008759, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (119, N'菜单删除', 81, 0, N'', 2, 1, N'system:menu:remove', N'', N'1', 1577008778, N'0', 1577008778, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (120, N'角色查询', 85, 0, N'', 2, 1, N'system:role:query', N'', N'1', 1577008889, N'0', 1577008889, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (121, N'角色新增', 85, 0, N'', 2, 1, N'system:role:add', N'', N'1', 1577008909, N'0', 1577008909, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (122, N'角色修改', 85, 0, N'', 2, 1, N'system:role:edit', N'', N'1', 1577008932, N'0', 1577008932, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (123, N'角色删除', 85, 0, N'', 2, 1, N'system:role:remove', N'', N'1', 1577008947, N'0', 1577008947, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (124, N'字典查询', 88, 0, N'', 2, 1, N'system:dict:query', N'', N'1', 1577009045, N'0', 1577009045, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (125, N'字典新增', 88, 0, N'', 2, 1, N'system:dict:add', N'', N'1', 1577009060, N'0', 1577009060, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (126, N'字典修改', 88, 0, N'', 2, 1, N'system:dict:edit', N'', N'1', 1577009078, N'0', 1577009078, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (127, N'字典删除', 88, 0, N'', 2, 1, N'system:dict:remove', N'', N'1', 1577009096, N'0', 1577009096, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (128, N'参数查询', 94, 0, N'', 2, 1, N'system:config:query', N'', N'1', 1577009161, N'0', 1577009161, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (129, N'参数新增', 94, 0, N'', 2, 1, N'system:config:add', N'', N'1', 1577009190, N'0', 1577009190, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (130, N'参数修改', 94, 0, N'', 2, 1, N'system:config:edit', N'', N'1', 1577009206, N'0', 1577009206, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (131, N'参数删除', 94, 0, N'', 2, 1, N'system:config:remove', N'', N'1', 1577009257, N'0', 1577009257, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (132, N'用户查询', 111, 0, N'', 2, 1, N'system:user:query', N'', N'1', 1577009499, N'1', 1577178595, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (133, N'用户新增', 111, 0, N'', 2, 1, N'system:user:add', N'', N'1', 1577009530, N'0', 1577009530, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (134, N'用户修改', 111, 0, N'', 2, 1, N'system:user:edit', N'', N'1', 1577009550, N'0', 1577009550, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (135, N'用户删除', 111, 0, N'', 2, 1, N'system:user:remove', N'', N'1', 1577009563, N'0', 1577009563, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (136, N'部门查询', 112, 0, N'', 2, 1, N'system:dept:query', N'', N'1', 1577009594, N'0', 1577009594, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (137, N'部门新增', 112, 0, N'', 2, 1, N'system:dept:add', N'', N'1', 1577009609, N'0', 1577009609, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (138, N'部门修改', 112, 0, N'', 2, 1, N'system:dept:edit', N'', N'1', 1577009622, N'0', 1577009622, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (139, N'部门删除', 112, 0, N'', 2, 1, N'system:dept:remove', N'', N'1', 1577009634, N'0', 1577009634, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (140, N'岗位查询', 113, 0, N'', 2, 1, N'system:post:query', N'', N'1', 1577009668, N'0', 1577009668, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (141, N'岗位新增', 113, 0, N'', 2, 1, N'system:post:add', N'', N'1', 1577009688, N'0', 1577009688, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (142, N'岗位修改', 113, 0, N'', 2, 1, N'system:post:edit', N'', N'1', 1577009707, N'0', 1577009707, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (143, N'岗位删除', 113, 0, N'', 2, 1, N'system:post:remove', N'', N'1', 1577009721, N'0', 1577009721, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (144, N'字典数据查询', 115, 0, N'', 2, 1, N'system:dict-data:query', N'', N'1', 1577009780, N'0', 1577009780, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (145, N'字典数据新增', 115, 0, N'', 2, 1, N'system:dict-data:add', N'', N'1', 1577009801, N'0', 1577009801, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (146, N'字典数据修改', 115, 0, N'', 2, 1, N'system:dict-data:edit', N'', N'1', 1577009819, N'0', 1577009819, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (147, N'字典数据删除', 115, 0, N'', 2, 1, N'system:dict-data:remove', N'', N'1', 1577009835, N'0', 1577009835, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (148, N'角色修改 - 数据权限', 85, 1, N'', 2, 1, N'system:role:editData', N'', N'1', 1577604292, N'1', 1577604597, N'')
INSERT [sys_menu] ([id], [menu_name], [parent_id], [order_num], [url], [menu_type], [visible], [perms], [icon], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (149, N'字典详情', 88, 1, N'', 2, 1, N'system:dict:detail', N'', N'1', 1577605276, N'0', 1577605276, N'')
SET IDENTITY_INSERT [sys_menu] OFF
INSERT [sys_role] ([id], [role_name], [role_key], [role_sort], [data_scope], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (1, N'管理员', N'api:post', 3, 1, 1, 1, N'77', 1573276666, N'1', 1577605900, N'管理员')
INSERT [sys_role] ([id], [role_name], [role_key], [role_sort], [data_scope], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (2, N'操作员', N'abc:111', 4, 2, 1, 1, N'77', 1573276851, N'1', 1577612606, N'操作员')
INSERT [sys_role] ([id], [role_name], [role_key], [role_sort], [data_scope], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (3, N'普工员工', N'staff', 1, 1, 1, 1, N'1', 1577184737, N'1', 1577197097, N'')
INSERT [sys_role] ([id], [role_name], [role_key], [role_sort], [data_scope], [status], [del_flag], [create_by], [created_at], [update_by], [updated_at], [remark]) VALUES (4, N'游客', N'guide', 1, 1, 1, 1, N'1', 1577190381, N'0', 1577190381, N'')
SET IDENTITY_INSERT [sys_user] ON 

INSERT [sys_user] ([id], [login_name], [user_name], [user_type], [email], [phone], [phonenumber], [sex], [avatar], [password], [salt], [status], [del_flag], [login_ip], [login_date], [create_by], [created_at], [update_by], [updated_at], [deleted_at], [remark]) VALUES (1, N'admin', N'admin', 1, N'admin@admin.com', N'13666666666', N'', 1, N'', N'57a5a32caefe163a49e86c9b0e87c3d2', N'NYWFZ', 1, 0, N'112.39.58.220', 1586129174, N'1', 1577612511, N'0', 1586129174, NULL, N'')
INSERT [sys_user] ([id], [login_name], [user_name], [user_type], [email], [phone], [phonenumber], [sex], [avatar], [password], [salt], [status], [del_flag], [login_ip], [login_date], [create_by], [created_at], [update_by], [updated_at], [deleted_at], [remark]) VALUES (2, N'noob', N'noob', 1, N'noob@qq.com', N'13888888888', N'', 1, N'', N'7564a6f55f347a66ec61873893964cb2', N'TAWTB', 1, 0, N'117.182.54.136', 1584251287, N'1', 1577722410, N'0', 1584251287, NULL, N'')
SET IDENTITY_INSERT [sys_user] OFF
/****** Object:  Index [PK_sys_admin_log]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_admin_log] ADD  CONSTRAINT [PK_sys_admin_log] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_area]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_area] ADD  CONSTRAINT [PK_sys_area] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [adcode]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_area] ADD  CONSTRAINT [adcode] UNIQUE NONCLUSTERED 
(
	[adcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_article]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_article] ADD  CONSTRAINT [PK_sys_article] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [created_at]    Script Date: 2020/4/8 23:47:48 ******/
CREATE NONCLUSTERED INDEX [created_at] ON [sys_article]
(
	[created_at] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_category]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_category] ADD  CONSTRAINT [PK_sys_category] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [pid]    Script Date: 2020/4/8 23:47:48 ******/
CREATE NONCLUSTERED INDEX [pid] ON [sys_category]
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [weigh]    Script Date: 2020/4/8 23:47:48 ******/
CREATE NONCLUSTERED INDEX [weigh] ON [sys_category]
(
	[weigh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_dept]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_dept] ADD  CONSTRAINT [PK_sys_dept] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [dict_type]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_dict_type] ADD  CONSTRAINT [dict_type] UNIQUE NONCLUSTERED 
(
	[dict_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_post]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_post] ADD  CONSTRAINT [PK_sys_post] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_role_dept]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_role_dept] ADD  CONSTRAINT [PK_sys_role_dept] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_role_menu]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_role_menu] ADD  CONSTRAINT [PK_sys_role_menu] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [email]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_user] ADD  CONSTRAINT [email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [phone]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_user] ADD  CONSTRAINT [phone] UNIQUE NONCLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [user_name]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_user] ADD  CONSTRAINT [user_name] UNIQUE NONCLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_user_post]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_user_post] ADD  CONSTRAINT [PK_sys_user_post] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sys_user_role]    Script Date: 2020/4/8 23:47:48 ******/
ALTER TABLE [sys_user_role] ADD  CONSTRAINT [PK_sys_user_role] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [sys_admin_log] ADD  DEFAULT ((0)) FOR [user_id]
GO
ALTER TABLE [sys_admin_log] ADD  DEFAULT ('0') FOR [ip]
GO
ALTER TABLE [sys_admin_log] ADD  DEFAULT ((0)) FOR [created_at]
GO
ALTER TABLE [sys_area] ADD  DEFAULT ('1') FOR [is_end]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [category_id]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((1)) FOR [post_status]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((1)) FOR [comment_status]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [flag]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [post_hits]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [post_favorites]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [post_like]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [comment_count]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [created_at]
GO
ALTER TABLE [sys_article] ADD  DEFAULT ((0)) FOR [updated_at]
GO
ALTER TABLE [sys_category] ADD  DEFAULT ((0)) FOR [pid]
GO
ALTER TABLE [sys_category] ADD  DEFAULT ((1)) FOR [type]
GO
ALTER TABLE [sys_category] ADD  DEFAULT ((0)) FOR [flag]
GO
ALTER TABLE [sys_category] ADD  DEFAULT ((0)) FOR [is_nav]
GO
ALTER TABLE [sys_category] ADD  DEFAULT ((0)) FOR [weigh]
GO
ALTER TABLE [sys_category] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [sys_category] ADD  DEFAULT ('list') FOR [tpl]
GO
ALTER TABLE [sys_configs] ADD  CONSTRAINT [DF__sys_confi__confi__59FA5E80]  DEFAULT ('1') FOR [config_type]
GO
ALTER TABLE [sys_dept] ADD  CONSTRAINT [DF__sys_dept__parent__5AEE82B9]  DEFAULT ((0)) FOR [parent_id]
GO
ALTER TABLE [sys_dept] ADD  CONSTRAINT [DF__sys_dept__order___5BE2A6F2]  DEFAULT ((0)) FOR [order_num]
GO
ALTER TABLE [sys_dept] ADD  CONSTRAINT [DF__sys_dept__status__5CD6CB2B]  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [sys_dept] ADD  CONSTRAINT [DF__sys_dept__del_fl__5DCAEF64]  DEFAULT ('0') FOR [del_flag]
GO
ALTER TABLE [sys_dict_data] ADD  CONSTRAINT [DF__sys_dict___dict___5EBF139D]  DEFAULT ((0)) FOR [dict_sort]
GO
ALTER TABLE [sys_dict_data] ADD  CONSTRAINT [DF__sys_dict___is_de__5FB337D6]  DEFAULT ('N') FOR [is_default]
GO
ALTER TABLE [sys_dict_data] ADD  CONSTRAINT [DF__sys_dict___statu__60A75C0F]  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [sys_dict_type] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [sys_menu] ADD  CONSTRAINT [DF__sys_menu_parent_id]  DEFAULT ((0)) FOR [parent_id]
GO
ALTER TABLE [sys_menu] ADD  CONSTRAINT [DF__sys_menu_order_num]  DEFAULT ((0)) FOR [order_num]
GO
ALTER TABLE [sys_menu] ADD  CONSTRAINT [DF__sys_menu_url]  DEFAULT ('#') FOR [url]
GO
ALTER TABLE [sys_menu] ADD  CONSTRAINT [DF__sys_menu_visible]  DEFAULT ('0') FOR [visible]
GO
ALTER TABLE [sys_menu] ADD  CONSTRAINT [DF__sys_menu_icon]  DEFAULT ('#') FOR [icon]
GO
ALTER TABLE [sys_role] ADD  CONSTRAINT [DF__sys_role__data_s__6754599E]  DEFAULT ('1') FOR [data_scope]
GO
ALTER TABLE [sys_role] ADD  CONSTRAINT [DF__sys_role__del_fl__68487DD7]  DEFAULT ('0') FOR [del_flag]
GO
ALTER TABLE [sys_user] ADD  CONSTRAINT [DF__sys_user_del_flag]  DEFAULT ((1)) FOR [user_type]
GO
ALTER TABLE [sys_user] ADD  CONSTRAINT [DF__sys_user_sex]  DEFAULT ('1') FOR [sex]
GO
ALTER TABLE [sys_user] ADD  CONSTRAINT [DF__sys_user_status]  DEFAULT ('1') FOR [status]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后台用户日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_admin_log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地区信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'post标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发表者用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'author'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态;1:已发布;0:未发布;' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评论状态;1:允许;0:不允许' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'comment_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1热门，2首页，3推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_hits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收藏数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_favorites'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点赞数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_like'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评论数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'comment_count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'seo keywords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_keywords'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'post摘要' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_excerpt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转载文章的来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缩略图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'post_content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_article'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'pid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'别名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0,1火,2首页,3推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外链' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'href'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是导航' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'is_nav'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'keywords'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'deleted_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'weigh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模板文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category', @level2type=N'COLUMN',@level2name=N'tpl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'config_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数键名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'config_key'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数键值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'config_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统内置（1是 2否）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'config_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新着' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'deleted_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数配置表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_configs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父部门id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'parent_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'祖级列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'ancestors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'dept_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'order_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'leader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标志（0代表存在 2代表删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'del_flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dict_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dict_sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dict_label'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典键值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dict_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dict_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样式属性（其他样式扩展）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'css_class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表格回显样式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'list_class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否默认（Y是 N否）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'is_default'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典数据表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'dict_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'dict_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'dict_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'menu_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'parent_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'order_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单类型（1,目录 2,菜单 3,按钮）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'menu_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单状态（0显示 1隐藏）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'visible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'perms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'post_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'post_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'post_sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'role_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'role_key'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'role_sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据范围（1：全部数据权限 2：自定数据权限）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'data_scope'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标志（0代表存在 2代表删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'del_flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_dept', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_dept', @level2type=N'COLUMN',@level2name=N'dept_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色和部门关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_dept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu', @level2type=N'COLUMN',@level2name=N'menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色和菜单关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'login_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型（1系统用户）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'user_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'phonenumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户性别（1男 2女 3未知）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'avatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盐加密' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'salt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号状态（1正常 2禁用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标志（1代表存在 2代表删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'del_flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登陆IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'login_ip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登陆时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'login_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'created_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'updated_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'deleted_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_post', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_post', @level2type=N'COLUMN',@level2name=N'post_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户与岗位关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_post'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_role', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_role', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户和角色关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_role'
GO
