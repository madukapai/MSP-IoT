/****** Object:  Table [dbo].[IoTEvents]    Script Date: 2016/8/5 ¤U¤È 08:19:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IoTEvents](
	[DeviceId] [nvarchar](max) NULL,
	[Temperature] [decimal](18, 1) NULL,
	[Humidity] [decimal](18, 1) NULL,
	[PM25] [decimal](18, 1) NULL,
	[SendDateTime] [datetime] NULL
)

GO

