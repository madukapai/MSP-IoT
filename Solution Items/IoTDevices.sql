
CREATE TABLE [dbo].[IoTDevices](
	[DeviceId] [nvarchar](50) NOT NULL,
	[DeviceKey] [nvarchar](max) NULL,
 CONSTRAINT [PK_IoTDevices] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

