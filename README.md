# TestFreesql
测试复现Freesql的bug

新建一个 数据库TestFreesql, 或修改 form1中的连接字符串
插入几条数据


```sql
CREATE TABLE [dbo].[tTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_tTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tTest] ON 
GO
INSERT [dbo].[tTest] ([Id], [Name], [Type]) VALUES (2, N'成功', 0)
GO
INSERT [dbo].[tTest] ([Id], [Name], [Type]) VALUES (3, N'失败', 1)
GO
SET IDENTITY_INSERT [dbo].[tTest] OFF
GO
```

点击button，报错：
```
System.Exception
  HResult=0x80131500
  Message=ExpressionTree 转换类型错误，值(已成功)，类型(TestFreesql.AppEnum+Type1)，目标类型(TestFreesql.AppEnum+Type2)，未找到请求的值“已成功”。
  Source=FreeSql
  StackTrace:
   在 FreeSql.Internal.CommonProvider.AdoProvider.LoggerException(IObjectPool`1 pool, PrepareCommandResult pc, Exception ex, DateTime dt, StringBuilder logtxt, Boolean isThrowException) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\AdoProvider\AdoProvider.cs 中: 第 92 行
   在 FreeSql.Internal.CommonProvider.AdoProvider.ExecuteReaderMultiple(Int32 multipleResult, DbConnection connection, DbTransaction transaction, Action`2 fetchHandler, Action`2 schemaHandler, CommandType cmdType, String cmdText, Int32 cmdTimeout, DbParameter[] cmdParms) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\AdoProvider\AdoProvider.cs 中: 第 688 行
   在 FreeSql.Internal.CommonProvider.AdoProvider.ExecuteReader(DbConnection connection, DbTransaction transaction, Action`1 fetchHandler, CommandType cmdType, String cmdText, Int32 cmdTimeout, DbParameter[] cmdParms) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\AdoProvider\AdoProvider.cs 中: 第 559 行
   在 FreeSql.Internal.CommonProvider.Select0Provider`2.ToListMrPrivate[TReturn](String sql, ReadAnonymousTypeAfInfo af, ReadAnonymousTypeOtherInfo[] otherData) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\SelectProvider\Select0ProviderReader.cs 中: 第 330 行
   在 FreeSql.Internal.CommonProvider.Select0Provider`2.ToListMapReaderPrivate[TReturn](ReadAnonymousTypeAfInfo af, ReadAnonymousTypeOtherInfo[] otherData) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\SelectProvider\Select0ProviderReader.cs 中: 第 355 行
   在 FreeSql.Internal.CommonProvider.Select0Provider`2.ToListMapReader[TReturn](ReadAnonymousTypeAfInfo af) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\SelectProvider\Select0ProviderReader.cs 中: 第 357 行
   在 FreeSql.Internal.CommonProvider.Select0Provider`2.InternalToList[TReturn](Expression select) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\SelectProvider\Select0ProviderReader.cs 中: 第 766 行
   在 FreeSql.Internal.CommonProvider.Select1Provider`1.ToList[TReturn](Expression`1 select) 在 C:\Users\28810\Desktop\github\FreeSql\FreeSql\Internal\CommonProvider\SelectProvider\Select1Provider.cs 中: 第 195 行
   在 TestFreesql.Form1.button1_Click(Object sender, EventArgs e) 在 E:\git\TestFreesql\Form1.cs 中: 第 38 行
   在 System.Windows.Forms.Control.OnClick(EventArgs e)
   在 System.Windows.Forms.Button.OnClick(EventArgs e)
   在 System.Windows.Forms.Button.OnMouseUp(MouseEventArgs mevent)
   在 System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
   在 System.Windows.Forms.Control.WndProc(Message& m)
   在 System.Windows.Forms.ButtonBase.WndProc(Message& m)
   在 System.Windows.Forms.Button.WndProc(Message& m)
   在 System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
   在 System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   在 System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
   在 System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
   在 System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(IntPtr dwComponentID, Int32 reason, Int32 pvLoopData)
   在 System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
   在 System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
   在 System.Windows.Forms.Application.Run(Form mainForm)
   在 TestFreesql.Program.Main() 在 E:\git\TestFreesql\Program.cs 中: 第 19 行

  此异常最初是在此调用堆栈中引发的: 
    FreeSql.Internal.Utils.GetDataReaderValue(System.Type, object) (位于 UtilsExpressionTree.cs 中)
    FreeSql.Internal.CommonExpression.ReadAnonymous(FreeSql.Internal.Model.ReadAnonymousTypeInfo, System.Data.Common.DbDataReader, ref int, bool, FreeSql.Internal.CommonExpression.ReadAnonymousDbValueRef, int, System.Collections.Generic.List<FreeSql.Internal.Model.NativeTuple<string, System.Collections.IList, int>>) (位于 CommonExpression.cs 中)
    FreeSql.Internal.CommonExpression.ReadAnonymous(FreeSql.Internal.Model.ReadAnonymousTypeInfo, System.Data.Common.DbDataReader, ref int, bool, FreeSql.Internal.CommonExpression.ReadAnonymousDbValueRef, int, System.Collections.Generic.List<FreeSql.Internal.Model.NativeTuple<string, System.Collections.IList, int>>) (位于 CommonExpression.cs 中)
    FreeSql.Internal.CommonProvider.Select0Provider<TSelect, T1>.ToListMrPrivate.AnonymousMethod__0(FreeSql.Internal.Model.FetchCallbackArgs<System.Data.Common.DbDataReader>) (位于 Select0ProviderReader.cs 中)
    FreeSql.Internal.CommonProvider.AdoProvider.ExecuteReader.AnonymousMethod__0(FreeSql.Internal.Model.FetchCallbackArgs<System.Data.Common.DbDataReader>, int) (位于 AdoProvider.cs 中)
    FreeSql.Internal.CommonProvider.AdoProvider.ExecuteReaderMultiple(int, System.Data.Common.DbConnection, System.Data.Common.DbTransaction, System.Action<FreeSql.Internal.Model.FetchCallbackArgs<System.Data.Common.DbDataReader>, int>, System.Action<System.Data.Common.DbDataReader, int>, System.Data.CommandType, string, int, System.Data.Common.DbParameter[]) (位于 AdoProvider.cs 中)

内部异常 1:
ArgumentException: ExpressionTree 转换类型错误，值(已成功)，类型(TestFreesql.AppEnum+Type1)，目标类型(TestFreesql.AppEnum+Type2)，未找到请求的值“已成功”。
```
