﻿using System;
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
		///  账号冻结
		/// </summary>
		STATUS_BLOCKED = -30,

		// database
		ERROR_CODE__DB__INSERT = 1001,
		ERROR_CODE__DB__READ = 1002,
		ERROR_CODE__DB__UPDATE = 1003,
		ERROR_CODE__DB__NO_ROW = 1007,
		ERROR_CODE__DB__UNEXPECTED = 1008,
		ERROR_CODE__DB__TRANSACTION_BEGIN_FAILED = 1009,
		ERROR_CODE__DB__TRANSACTION_COMMIT_FAILED = 1010,
		ERROR_CODE__DB__UPDATE_UNEXPECTED = 1011,
		ERROR_CODE__DB__TRANSACTION_ROLLBACK_FAILED = 1010,

		// rbac
		ERROR_CODE__ROLE__NOT_EXIST = 5101,
		ERROR_CODE__USER_ROLE__NOT_EXIST = 5102,

		// parameter
		ERROR_CODE__PARAM__ILLEGAL = 1101,

		// address
		ERROR_CODE__PROVINCE__NOT_EXIST = 4801,
		ERROR_CODE__CITY__NOT_EXIST = 4802,
		ERROR_CODE__DISTRICT__NOT_EXIST = 4803,
		ERROR_CODE__STREET__NOT_EXIST = 4803,

		// json
		ERROR_CODE__JSON__UNMARSHAL_FAILED = 1105,

		// type
		ERROR_CODE__TYPE__INVALID = 4101,
		ERROR_CODE__ORG_TYPE__ILLEGAL = 4102,

		// rpc
		ERROR_CODE__RPC__CALL = 4401,

		// verification code
		ERROR_CODE__VERIFICATION_CODE__NOT_MATCH = 4501,

		// http	    
		/// <summary>
		/// 外部传入参数错误
		/// </summary>
		ERROR_CODE__SOURCE_DATA__ILLEGAL = 1101, // 外部传入参数错误
		ERROR_CODE__GRPC__FAILED = 1102, // grpc 调用失败
		ERROR_CODE__HTTP__CALL_FAILD_EXTERNAL = 1103, // http外部调用失败
		ERROR_CODE__HTTP__CALL_FAILD_INTERNAL = 1104, // http内部调用失败
		ERROR_CODE__JSON__PARSE_FAILED = 1105, // JSON解析失败
		ERROR_CODE__HTTP__INPUT_EMPTY = 1106,

		FIELD_IS_EMPTY = 1201, // 数据字段为空
		FIELD_DUPLICATE = 1202, // 数据字段重复

		// redis 调用失败
		REDIS_SET_FAILED = 1301,
		REDIS_GET_FAILED = 1302,

		// session
		ERROR_CODE__SESSION__START_FAILED = 1404,
		ERROR_CODE__SESSION__EMPTY_SESSION = 1410,
		ERROR_CODE__SESSION__SET_FAILED = 1411,

		// session 相关错误码
		SESSION_ERROR_NO_USER_ID = 1401,
		SESSION_ERROR_NO_COMPANY_ID = 1402,
		SESSION_ERROR_EMPTY_INPUT = 1403,
		SESSION_ERROR_START_FAIL = 1404,
		SESSION_ERROR_NO_USER_NAME = 1405,
		SESSION_ERROR_NO_COMPANY_NAME = 1406,
		SESSION_ERROR_EMPTY_SESSION = 1407,
		SESSION_ERROR_INVALID_USER_ID = 1408,
		SESSION_ERROR_INVALID_COMPANY_ID = 1409,
		SESSION_ERROR_NO_SESSION = 1410,

		// header 相关错误码
		ERROR_CODE__HEADER__NO_USER_ID = 1501,
		ERROR_CODE__HEADER__NO_COMPANY_ID = 1502,
		ERROR_CODE__HEADER__NO_USER_NAME = 1504,
		ERROR_CODE__HEADER__NO_COMPANY_NAME = 1505,
		ERROR_CODE__HEADER__NO_POSITIONS = 1506,
		ERROR_CODE__HEADER__POSITIONS_FORMAT_ILLEGAL = 1507,
		ERROR_CODE__HEADER__NO_USER_MOBILE = 1509,
		ERROR_CODE__HEADER__NO_USER_CODE = 1510,

		HEADER_ERROR_NO_USER_ID = 1501,
		HEADER_ERROR_NO_COMPANY_ID = 1502,
		HEADER_ERROR_EMPTY_INPUT = 1503,
		HEADER_ERROR_NO_USER_NAME = 1504,
		HEADER_ERROR_NO_COMPANY_NAME = 1505,

		// 用户状态
		USER_NOT_EXIST = 2001,
		USER_EXISTED = 2002,
		USER_PW_ERROR = 2003,
		USER_LOGGED_IN = 2004,
		USER_LOGGED_OUT = 2005,
		USER_ACTIVE = 2006, // 账号已启用
		USER_INACTIVE = 2006, // 账号未启用
		USER_UNBLOCKED = 2007, // 账号未冻结

		// etcd相关操作错误码
		ETCD_CREATE_DIR_ERROR = 3001,
		ETCD_CREATE_KEY_ERROR = 3002,
		ETCD_READ_KEY_ERROR = 3003,

		// IO文件解析错误码
		FILE_OPEN_FAILED = 4001,
		FILE_READ_FAILED = 4002,

		// GRBAC权限管理错误码
		GRBAC_PERMISSION_REJECT_ACCESS = 4021, // 拒绝访问，没有权限

	}
    /// <summary>
    /// Class ResponseBase.
    /// </summary>
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
		/// Initializes a new instance of the <see cref="ResponseBase{T}"/> class.
		/// </summary>
		public ResponseBase()
		{
			Code = (int)ResponseCode.ERROR;
			Msg = "error";
		}
		/// <summary>
		/// Errors this instance.
		/// </summary>
		/// <returns>ResponseBase&lt;T&gt;.</returns>
		public virtual ResponseBase<T> Error(int code,string msg){
			this.Code = code;
			this.Msg = msg;
			return this;
		}
		/// <summary>
		/// Errors this instance.
		/// </summary>
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
