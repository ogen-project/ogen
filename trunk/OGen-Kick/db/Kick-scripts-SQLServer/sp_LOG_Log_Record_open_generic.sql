ALTER PROCEDURE [sp_LOG_Log_Record_open_generic]
	@IDType_search_ int, 
	@IDUser_search_ bigint, 
	@IDError_search_ int, 
	@Stamp_begin_search_ datetime, 
	@Stamp_end_search_ datetime, 
	@Read_search_ bit, 
	@IFApplication_search_ int
AS
	SELECT
		t1.[IDLog]
	FROM [LOG_Log] t1
	INNER JOIN [fnc_LOG_Log_Record_open_generic](
		@IDType_search_, 
		@IDUser_search_, 
		@IDError_search_, 
		@Stamp_begin_search_, 
		@Stamp_end_search_, 
		@Read_search_, 
		@IFApplication_search_
	) t2 ON (
		(t2.[IDLog] = t1.[IDLog])
	)

	-- CHANGE WHERE CONDITION IN: [dbo].[fnc_LOG_Log_Record_open_generic]
	-- NOT HERE!

	-- CHANGE ORDER BY HERE:
	ORDER BY t1."IDLog" desc
GO
