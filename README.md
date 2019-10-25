# tools for coding
## dev by hy999 based on asp.net core 3.0

## update log (10/25/2019)
some apis incloud it:
some encryptions:md5(16/32),sha256,base64(inclould debase),etc...
email tools:smtp,etc....
## api list and mothed
### base64 (get)
api/v1/encryption/base64
	type -> encryptionType/编码类型
		encode -> 加密
		decode -> 解密
	strEncoding -> str's encoding Type / 字符类型
  	conStr -> content / 加密内容
	resStr -> result / 返回结果 （no required!）

### sha256 (get)
api/v1/encryption/sha256
	contStr -> constent / 加密内容
	resStr -> result / 返回结果 （no required!）

### md5 (get)
api/vi/encryption/md5
	md5Type -> md5 encryption type
		md516 -> 16bit result  / 16位返回结果
		md532 -> 32bit result / 32位返回结果
	contStr -> content / 加密内容
	resStr -> result / 返回结果 （no required!）
### smtp (post)
api/v1/email/smtp
	fromEmail -> sender's email address / 发送邮箱
	toEmail -> recciver's email address / 收信邮箱
	emailTitle -> post's titl / 邮件标题
	emailContent -> post's content / 邮件内容
	emailPasswd -> fromEmail's password / 发送邮件邮箱密码
	emailHost -> email server host /发送邮箱服务器
	isSSL -> open or close ssl / 是否开启 ssl访问
		true -> open / 开启
		false -> close / 关闭
	isHtml -> open or close html encryption / 是否开启html编码
		true -> open / 开启
                false -> close / 关闭


