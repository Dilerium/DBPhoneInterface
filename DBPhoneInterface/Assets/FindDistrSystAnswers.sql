USE [AcademicQandA]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[FindADistrSystByTags]
		@Tag1 = N'Intention',
		@Tag2 = N'Goal'

SELECT	@return_value as 'Return Value'

GO
