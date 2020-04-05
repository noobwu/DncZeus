// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="ResponseBase.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
	/// <summary>
	/// Enum ResponseCode
	/// </summary>
	public enum ResponseCode
    {
		/// <summary>
		/// The success
		/// </summary>
		SUCCESS = 0,
		/// <summary>
		/// The error
		/// </summary>
		ERROR = 1,
		/// <summary>
		/// The invalid parameters
		/// </summary>
		INVALID_PARAMS = 400,

		/// <summary>
		/// The error exist tag
		/// </summary>
		ERROR_EXIST_TAG = 10001,
		/// <summary>
		/// The error not exist tag
		/// </summary>
		ERROR_NOT_EXIST_TAG = 10002,
		/// <summary>
		/// The error not exist article
		/// </summary>
		ERROR_NOT_EXIST_ARTICLE = 10003,

		/// <summary>
		/// The error authentication check token fail
		/// </summary>
		ERROR_AUTH_CHECK_TOKEN_FAIL = 20001,
		/// <summary>
		/// The error authentication check token timeout
		/// </summary>
		ERROR_AUTH_CHECK_TOKEN_TIMEOUT = 20002,
		/// <summary>
		/// The error authentication token
		/// </summary>
		ERROR_AUTH_TOKEN = 20003,
		/// <summary>
		/// The error authentication
		/// </summary>
		ERROR_AUTH = 20004,

		/// <summary>
		/// 账号有效或者已启用
		/// </summary>
		STATUS_VALID = 10,
		/// <summary>
		/// 临时
		/// </summary>
		STATUS_INVALID = -10,
		/// <summary>
		/// 账号未启用
		/// </summary>
		STATUS_INACTIVE = -10,
		/// <summary>
		/// 账号删除
		/// </summary>
		STATUS_DELETED = -20,
		/// <summary>
		/// 账号冻结
		/// </summary>
		STATUS_BLOCKED = -30,

		// database

		/// <summary>
		/// The error code database insert
		/// </summary>
		ERROR_CODE__DB__INSERT = 1001,
		/// <summary>
		/// The error code database read
		/// </summary>
		ERROR_CODE__DB__READ = 1002,
		/// <summary>
		/// The error code database update
		/// </summary>
		ERROR_CODE__DB__UPDATE = 1003,
		/// <summary>
		/// The error code database no row
		/// </summary>
		ERROR_CODE__DB__NO_ROW = 1007,
		/// <summary>
		/// The error code database unexpected
		/// </summary>
		ERROR_CODE__DB__UNEXPECTED = 1008,
		/// <summary>
		/// The error code database transaction begin failed
		/// </summary>
		ERROR_CODE__DB__TRANSACTION_BEGIN_FAILED = 1009,
		/// <summary>
		/// The error code database transaction commit failed
		/// </summary>
		ERROR_CODE__DB__TRANSACTION_COMMIT_FAILED = 1010,
		/// <summary>
		/// The error code database update unexpected
		/// </summary>
		ERROR_CODE__DB__UPDATE_UNEXPECTED = 1011,
		/// <summary>
		/// The error code database transaction rollback failed
		/// </summary>
		ERROR_CODE__DB__TRANSACTION_ROLLBACK_FAILED = 1010,

		// rbac
		/// <summary>
		/// The error code role not exist
		/// </summary>
		ERROR_CODE__ROLE__NOT_EXIST = 5101,
		/// <summary>
		/// The error code user role not exist
		/// </summary>
		ERROR_CODE__USER_ROLE__NOT_EXIST = 5102,

		// parameter
		/// <summary>
		/// The error code parameter illegal
		/// </summary>
		ERROR_CODE__PARAM__ILLEGAL = 1101,

		// address
		/// <summary>
		/// The error code province not exist
		/// </summary>
		ERROR_CODE__PROVINCE__NOT_EXIST = 4801,
		/// <summary>
		/// The error code city not exist
		/// </summary>
		ERROR_CODE__CITY__NOT_EXIST = 4802,
		/// <summary>
		/// The error code district not exist
		/// </summary>
		ERROR_CODE__DISTRICT__NOT_EXIST = 4803,
		/// <summary>
		/// The error code street not exist
		/// </summary>
		ERROR_CODE__STREET__NOT_EXIST = 4803,

		// json
		/// <summary>
		/// The error code json unmarshal failed
		/// </summary>
		ERROR_CODE__JSON__UNMARSHAL_FAILED = 1105,

		// type
		/// <summary>
		/// The error code type invalid
		/// </summary>
		ERROR_CODE__TYPE__INVALID = 4101,
		/// <summary>
		/// The error code org type illegal
		/// </summary>
		ERROR_CODE__ORG_TYPE__ILLEGAL = 4102,

		// rpc
		/// <summary>
		/// The error code RPC call
		/// </summary>
		ERROR_CODE__RPC__CALL = 4401,

		// verification code
		/// <summary>
		/// The error code verification code not match
		/// </summary>
		ERROR_CODE__VERIFICATION_CODE__NOT_MATCH = 4501,

		// http	    
		/// <summary>
		/// 外部传入参数错误
		/// </summary>
		ERROR_CODE__SOURCE_DATA__ILLEGAL = 1101, // 外部传入参数错误
		/// <summary>
		/// The error code GRPC failed
		/// </summary>
		ERROR_CODE__GRPC__FAILED = 1102, // grpc 调用失败
		/// <summary>
		/// The error code HTTP call faild external
		/// </summary>
		ERROR_CODE__HTTP__CALL_FAILD_EXTERNAL = 1103, // http外部调用失败
		/// <summary>
		/// The error code HTTP call faild internal
		/// </summary>
		ERROR_CODE__HTTP__CALL_FAILD_INTERNAL = 1104, // http内部调用失败
		/// <summary>
		/// The error code json parse failed
		/// </summary>
		ERROR_CODE__JSON__PARSE_FAILED = 1105, // JSON解析失败
		/// <summary>
		/// The error code HTTP input empty
		/// </summary>
		ERROR_CODE__HTTP__INPUT_EMPTY = 1106,

		/// <summary>
		/// The field is empty
		/// </summary>
		FIELD_IS_EMPTY = 1201, // 数据字段为空
		/// <summary>
		/// The field duplicate
		/// </summary>
		FIELD_DUPLICATE = 1202, // 数据字段重复

		// redis 调用失败
		/// <summary>
		/// The redis set failed
		/// </summary>
		REDIS_SET_FAILED = 1301,
		/// <summary>
		/// The redis get failed
		/// </summary>
		REDIS_GET_FAILED = 1302,

		// session
		/// <summary>
		/// The error code session start failed
		/// </summary>
		ERROR_CODE__SESSION__START_FAILED = 1404,
		/// <summary>
		/// The error code session empty session
		/// </summary>
		ERROR_CODE__SESSION__EMPTY_SESSION = 1410,
		/// <summary>
		/// The error code session set failed
		/// </summary>
		ERROR_CODE__SESSION__SET_FAILED = 1411,

		// session 相关错误码
		/// <summary>
		/// The session error no user identifier
		/// </summary>
		SESSION_ERROR_NO_USER_ID = 1401,
		/// <summary>
		/// The session error no company identifier
		/// </summary>
		SESSION_ERROR_NO_COMPANY_ID = 1402,
		/// <summary>
		/// The session error empty input
		/// </summary>
		SESSION_ERROR_EMPTY_INPUT = 1403,
		/// <summary>
		/// The session error start fail
		/// </summary>
		SESSION_ERROR_START_FAIL = 1404,
		/// <summary>
		/// The session error no user name
		/// </summary>
		SESSION_ERROR_NO_USER_NAME = 1405,
		/// <summary>
		/// The session error no company name
		/// </summary>
		SESSION_ERROR_NO_COMPANY_NAME = 1406,
		/// <summary>
		/// The session error empty session
		/// </summary>
		SESSION_ERROR_EMPTY_SESSION = 1407,
		/// <summary>
		/// The session error invalid user identifier
		/// </summary>
		SESSION_ERROR_INVALID_USER_ID = 1408,
		/// <summary>
		/// The session error invalid company identifier
		/// </summary>
		SESSION_ERROR_INVALID_COMPANY_ID = 1409,
		/// <summary>
		/// The session error no session
		/// </summary>
		SESSION_ERROR_NO_SESSION = 1410,

		// header 相关错误码
		/// <summary>
		/// The error code header no user identifier
		/// </summary>
		ERROR_CODE__HEADER__NO_USER_ID = 1501,
		/// <summary>
		/// The error code header no company identifier
		/// </summary>
		ERROR_CODE__HEADER__NO_COMPANY_ID = 1502,
		/// <summary>
		/// The error code header no user name
		/// </summary>
		ERROR_CODE__HEADER__NO_USER_NAME = 1504,
		/// <summary>
		/// The error code header no company name
		/// </summary>
		ERROR_CODE__HEADER__NO_COMPANY_NAME = 1505,
		/// <summary>
		/// The error code header no positions
		/// </summary>
		ERROR_CODE__HEADER__NO_POSITIONS = 1506,
		/// <summary>
		/// The error code header positions format illegal
		/// </summary>
		ERROR_CODE__HEADER__POSITIONS_FORMAT_ILLEGAL = 1507,
		/// <summary>
		/// The error code header no user mobile
		/// </summary>
		ERROR_CODE__HEADER__NO_USER_MOBILE = 1509,
		/// <summary>
		/// The error code header no user code
		/// </summary>
		ERROR_CODE__HEADER__NO_USER_CODE = 1510,

		/// <summary>
		/// The header error no user identifier
		/// </summary>
		HEADER_ERROR_NO_USER_ID = 1501,
		/// <summary>
		/// The header error no company identifier
		/// </summary>
		HEADER_ERROR_NO_COMPANY_ID = 1502,
		/// <summary>
		/// The header error empty input
		/// </summary>
		HEADER_ERROR_EMPTY_INPUT = 1503,
		/// <summary>
		/// The header error no user name
		/// </summary>
		HEADER_ERROR_NO_USER_NAME = 1504,
		/// <summary>
		/// The header error no company name
		/// </summary>
		HEADER_ERROR_NO_COMPANY_NAME = 1505,

		// 用户状态
		/// <summary>
		/// The user not exist
		/// </summary>
		USER_NOT_EXIST = 2001,
		/// <summary>
		/// The user existed
		/// </summary>
		USER_EXISTED = 2002,
		/// <summary>
		/// The user pw error
		/// </summary>
		USER_PW_ERROR = 2003,
		/// <summary>
		/// The user logged in
		/// </summary>
		USER_LOGGED_IN = 2004,
		/// <summary>
		/// The user logged out
		/// </summary>
		USER_LOGGED_OUT = 2005,
		/// <summary>
		/// The user active
		/// </summary>
		USER_ACTIVE = 2006, // 账号已启用
		/// <summary>
		/// The user inactive
		/// </summary>
		USER_INACTIVE = 2006, // 账号未启用
		/// <summary>
		/// The user unblocked
		/// </summary>
		USER_UNBLOCKED = 2007, // 账号未冻结

		// etcd相关操作错误码
		/// <summary>
		/// The etcd create dir error
		/// </summary>
		ETCD_CREATE_DIR_ERROR = 3001,
		/// <summary>
		/// The etcd create key error
		/// </summary>
		ETCD_CREATE_KEY_ERROR = 3002,
		/// <summary>
		/// The etcd read key error
		/// </summary>
		ETCD_READ_KEY_ERROR = 3003,

		// IO文件解析错误码
		/// <summary>
		/// The file open failed
		/// </summary>
		FILE_OPEN_FAILED = 4001,
		/// <summary>
		/// The file read failed
		/// </summary>
		FILE_READ_FAILED = 4002,

		// GRBAC权限管理错误码
		/// <summary>
		/// The grbac permission reject access
		/// </summary>
		GRBAC_PERMISSION_REJECT_ACCESS = 4021, // 拒绝访问，没有权限

	}
	/// <summary>
	/// Class ResponseBase.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
    public class ResponseBase<T> where T:ResultBase
    {
		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		[JsonPropertyName("code")]
        public int Code { get; set; }
		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		[JsonPropertyName("data")]
        public T Data { get; set; }
		/// <summary>
		/// Gets or sets the MSG.
		/// </summary>
		/// <value>The MSG.</value>
		[JsonPropertyName("msg")]
        public string Msg { get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseBase{T}" /> class.
		/// </summary>
		public ResponseBase()
		{
			Code = (int)ResponseCode.ERROR;
			Msg = "error";
		}
		/// <summary>
		/// Errors this instance.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="msg">The MSG.</param>
		/// <returns>ResponseBase&lt;T&gt;.</returns>
		public virtual ResponseBase<T> Error(int code,string msg){
			this.Code = code;
			this.Msg = msg;
			return this;
		}
		/// <summary>
		/// Errors this instance.
		/// </summary>
		/// <param name="msg">The MSG.</param>
		/// <param name="data">The data.</param>
		/// <returns>ResponseBase&lt;T&gt;.</returns>
		public virtual ResponseBase<T> Success(string msg,T data=default(T))
		{
			this.Code = (int)ResponseCode.SUCCESS;
			this.Msg = msg;
			this.Data = data;
			return this;
		}
	}
}
