USE [SINU]
GO
/****** Object:  Synonym [dbo].[Syn_Param_Prov]    Script Date: 01/06/2020 18:22:45 ******/
CREATE SYNONYM [dbo].[Syn_Param_Prov] FOR [Parametricas].[dbo].[T015_PROVINCIAS]
GO
EXEC sys.sp_addextendedproperty @name=N'Descripcion', @value=N'Synonim que accede a la base Parametricas para ver Tabla T015_PROVINCIAS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'SYNONYM',@level1name=N'Syn_Param_Prov'
GO
