ALTER TABLE "CRD_User" WITH CHECK 
	ADD CONSTRAINT "CRD_User_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_User" CHECK CONSTRAINT "CRD_User_IFApplication_fkey"
GO

ALTER TABLE "CRD_ProfilePermission" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermission_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfilePermission" CHECK CONSTRAINT "CRD_ProfilePermission_IFProfile_fkey"
GO

ALTER TABLE "CRD_ProfilePermission" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermission_IFPermission_fkey" FOREIGN KEY (
		"IFPermission"
	) REFERENCES "CRD_Permission" (
		"IDPermission"
	)
GO
ALTER TABLE "CRD_ProfilePermission" CHECK CONSTRAINT "CRD_ProfilePermission_IFPermission_fkey"
GO

ALTER TABLE "DIC_Language" WITH CHECK 
	ADD CONSTRAINT "DIC_Language_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "DIC_Language" CHECK CONSTRAINT "DIC_Language_TX_Name_fkey"
GO

ALTER TABLE "DIC_Text" WITH CHECK 
	ADD CONSTRAINT "DIC_Text_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "DIC_Text" CHECK CONSTRAINT "DIC_Text_IFApplication_fkey"
GO

ALTER TABLE "DIC_TextLanguage" WITH CHECK 
	ADD CONSTRAINT "DIC_TextLanguage_IFLanguage_fkey" FOREIGN KEY (
		"IFLanguage"
	) REFERENCES "DIC_Language" (
		"IDLanguage"
	)
GO
ALTER TABLE "DIC_TextLanguage" CHECK CONSTRAINT "DIC_TextLanguage_IFLanguage_fkey"
GO

ALTER TABLE "DIC_TextLanguage" WITH CHECK 
	ADD CONSTRAINT "DIC_TextLanguage_IFText_fkey" FOREIGN KEY (
		"IFText"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "DIC_TextLanguage" CHECK CONSTRAINT "DIC_TextLanguage_IFText_fkey"
GO

ALTER TABLE "DIC_LanguageApplication" WITH CHECK 
	ADD CONSTRAINT "DIC_LanguageApplication_IFLanguage_fkey" FOREIGN KEY (
		"IFLanguage"
	) REFERENCES "DIC_Language" (
		"IDLanguage"
	)
GO
ALTER TABLE "DIC_LanguageApplication" CHECK CONSTRAINT "DIC_LanguageApplication_IFLanguage_fkey"
GO

ALTER TABLE "DIC_LanguageApplication" WITH CHECK 
	ADD CONSTRAINT "DIC_LanguageApplication_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "DIC_LanguageApplication" CHECK CONSTRAINT "DIC_LanguageApplication_IFApplication_fkey"
GO

ALTER TABLE "NWS_Attachment" WITH CHECK 
	ADD CONSTRAINT "NWS_Attachment_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_Attachment" CHECK CONSTRAINT "NWS_Attachment_IFContent_fkey"
GO

ALTER TABLE "NWS_Attachment" WITH CHECK 
	ADD CONSTRAINT "NWS_Attachment_TX_Description_fkey" FOREIGN KEY (
		"TX_Description"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Attachment" CHECK CONSTRAINT "NWS_Attachment_TX_Description_fkey"
GO

ALTER TABLE "NWS_Attachment" WITH CHECK 
	ADD CONSTRAINT "NWS_Attachment_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Attachment" CHECK CONSTRAINT "NWS_Attachment_TX_Name_fkey"
GO

ALTER TABLE "NWS_ContentTag" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentTag_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentTag" CHECK CONSTRAINT "NWS_ContentTag_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentTag" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentTag_IFTag_fkey" FOREIGN KEY (
		"IFTag"
	) REFERENCES "NWS_Tag" (
		"IDTag"
	)
GO
ALTER TABLE "NWS_ContentTag" CHECK CONSTRAINT "NWS_ContentTag_IFTag_fkey"
GO

ALTER TABLE "NWS_ContentSource" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentSource_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentSource" CHECK CONSTRAINT "NWS_ContentSource_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentSource" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentSource_IFSource_fkey" FOREIGN KEY (
		"IFSource"
	) REFERENCES "NWS_Source" (
		"IDSource"
	)
GO
ALTER TABLE "NWS_ContentSource" CHECK CONSTRAINT "NWS_ContentSource_IFSource_fkey"
GO

ALTER TABLE "NWS_ContentHighlight" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentHighlight_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentHighlight" CHECK CONSTRAINT "NWS_ContentHighlight_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentHighlight" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentHighlight_IFHighlight_fkey" FOREIGN KEY (
		"IFHighlight"
	) REFERENCES "NWS_Highlight" (
		"IDHighlight"
	)
GO
ALTER TABLE "NWS_ContentHighlight" CHECK CONSTRAINT "NWS_ContentHighlight_IFHighlight_fkey"
GO

ALTER TABLE "NWS_ContentAuthor" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentAuthor_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentAuthor" CHECK CONSTRAINT "NWS_ContentAuthor_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentAuthor" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentAuthor_IFAuthor_fkey" FOREIGN KEY (
		"IFAuthor"
	) REFERENCES "NWS_Author" (
		"IDAuthor"
	)
GO
ALTER TABLE "NWS_ContentAuthor" CHECK CONSTRAINT "NWS_ContentAuthor_IFAuthor_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_IFApplication_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_IFUser__Publisher_fkey" FOREIGN KEY (
		"IFUser__Publisher"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_IFUser__Publisher_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Summary_fkey" FOREIGN KEY (
		"TX_Summary"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Summary_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Subtitle_fkey" FOREIGN KEY (
		"TX_Subtitle"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Subtitle_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Content_fkey" FOREIGN KEY (
		"TX_Content"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Content_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Title_fkey" FOREIGN KEY (
		"TX_Title"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Title_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_IFUser__Approved_fkey"
GO

ALTER TABLE "FOR_Message" WITH CHECK 
	ADD CONSTRAINT "FOR_Message_IFMessage__parent_fkey" FOREIGN KEY (
		"IFMessage__parent"
	) REFERENCES "FOR_Message" (
		"IDMessage"
	)
GO
ALTER TABLE "FOR_Message" CHECK CONSTRAINT "FOR_Message_IFMessage__parent_fkey"
GO

ALTER TABLE "FOR_Message" WITH CHECK 
	ADD CONSTRAINT "FOR_Message_IFUser__Publisher_fkey" FOREIGN KEY (
		"IFUser__Publisher"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "FOR_Message" CHECK CONSTRAINT "FOR_Message_IFUser__Publisher_fkey"
GO

ALTER TABLE "FOR_Message" WITH CHECK 
	ADD CONSTRAINT "FOR_Message_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FOR_Message" CHECK CONSTRAINT "FOR_Message_IFApplication_fkey"
GO

ALTER TABLE "NWS_Source" WITH CHECK 
	ADD CONSTRAINT "NWS_Source_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Source" CHECK CONSTRAINT "NWS_Source_IFApplication_fkey"
GO

ALTER TABLE "NWS_Source" WITH CHECK 
	ADD CONSTRAINT "NWS_Source_IFSource__parent_fkey" FOREIGN KEY (
		"IFSource__parent"
	) REFERENCES "NWS_Source" (
		"IDSource"
	)
GO
ALTER TABLE "NWS_Source" CHECK CONSTRAINT "NWS_Source_IFSource__parent_fkey"
GO

ALTER TABLE "NWS_Source" WITH CHECK 
	ADD CONSTRAINT "NWS_Source_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Source" CHECK CONSTRAINT "NWS_Source_IFUser__Approved_fkey"
GO

ALTER TABLE "NWS_Highlight" WITH CHECK 
	ADD CONSTRAINT "NWS_Highlight_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Highlight" CHECK CONSTRAINT "NWS_Highlight_IFApplication_fkey"
GO

ALTER TABLE "NWS_Highlight" WITH CHECK 
	ADD CONSTRAINT "NWS_Highlight_IFHighlight__parent_fkey" FOREIGN KEY (
		"IFHighlight__parent"
	) REFERENCES "NWS_Highlight" (
		"IDHighlight"
	)
GO
ALTER TABLE "NWS_Highlight" CHECK CONSTRAINT "NWS_Highlight_IFHighlight__parent_fkey"
GO

ALTER TABLE "NWS_Highlight" WITH CHECK 
	ADD CONSTRAINT "NWS_Highlight_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Highlight" CHECK CONSTRAINT "NWS_Highlight_IFUser__Approved_fkey"
GO

ALTER TABLE "NWS_Author" WITH CHECK 
	ADD CONSTRAINT "NWS_Author_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Author" CHECK CONSTRAINT "NWS_Author_IFApplication_fkey"
GO

ALTER TABLE "NWS_Author" WITH CHECK 
	ADD CONSTRAINT "NWS_Author_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Author" CHECK CONSTRAINT "NWS_Author_IFUser__Approved_fkey"
GO

ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_IFApplication_fkey"
GO

ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_IFTag__parent_fkey" FOREIGN KEY (
		"IFTag__parent"
	) REFERENCES "NWS_Tag" (
		"IDTag"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_IFTag__parent_fkey"
GO

ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_TX_Name_fkey"
GO

ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_IFUser__Approved_fkey"
GO

ALTER TABLE "NWS_ContentProfile" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentProfile_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentProfile" CHECK CONSTRAINT "NWS_ContentProfile_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentProfile" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentProfile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "NWS_Profile" (
		"IFProfile"
	)
GO
ALTER TABLE "NWS_ContentProfile" CHECK CONSTRAINT "NWS_ContentProfile_IFProfile_fkey"
GO

ALTER TABLE "NWS_Profile" WITH CHECK 
	ADD CONSTRAINT "NWS_Profile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "NWS_Profile" CHECK CONSTRAINT "NWS_Profile_IFProfile_fkey"
GO

ALTER TABLE "NWS_Profile" WITH CHECK 
	ADD CONSTRAINT "NWS_Profile_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Profile" CHECK CONSTRAINT "NWS_Profile_IFUser__Approved_fkey"
GO

ALTER TABLE "NWS_UserTag" WITH CHECK 
	ADD CONSTRAINT "NWS_UserTag_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_UserTag" CHECK CONSTRAINT "NWS_UserTag_IFUser_fkey"
GO

ALTER TABLE "NWS_UserTag" WITH CHECK 
	ADD CONSTRAINT "NWS_UserTag_IFTag_fkey" FOREIGN KEY (
		"IFTag"
	) REFERENCES "NWS_Tag" (
		"IDTag"
	)
GO
ALTER TABLE "NWS_UserTag" CHECK CONSTRAINT "NWS_UserTag_IFTag_fkey"
GO

ALTER TABLE "LOG_Type" WITH CHECK 
	ADD CONSTRAINT "LOG_Type_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Type" CHECK CONSTRAINT "LOG_Type_IFApplication_fkey"
GO

ALTER TABLE "LOG_Type" WITH CHECK 
	ADD CONSTRAINT "LOG_Type_IFType_parent_fkey" FOREIGN KEY (
		"IFType_parent"
	) REFERENCES "LOG_Type" (
		"IDType"
	)
GO
ALTER TABLE "LOG_Type" CHECK CONSTRAINT "LOG_Type_IFType_parent_fkey"
GO

ALTER TABLE "LOG_Error" WITH CHECK 
	ADD CONSTRAINT "LOG_Error_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Error" CHECK CONSTRAINT "LOG_Error_IFApplication_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFUser_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFUser__read_fkey" FOREIGN KEY (
		"IFUser__read"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFUser__read_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFPermission_fkey" FOREIGN KEY (
		"IFPermission"
	) REFERENCES "CRD_Permission" (
		"IDPermission"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFPermission_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFApplication_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFType_fkey" FOREIGN KEY (
		"IFType"
	) REFERENCES "LOG_Type" (
		"IDType"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFType_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFError_fkey" FOREIGN KEY (
		"IFError"
	) REFERENCES "LOG_Error" (
		"IDError"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFError_fkey"
GO

ALTER TABLE "CRD_Permission" WITH CHECK 
	ADD CONSTRAINT "CRD_Permission_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_Permission" CHECK CONSTRAINT "CRD_Permission_IFApplication_fkey"
GO

ALTER TABLE "CRD_Permission" WITH CHECK 
	ADD CONSTRAINT "CRD_Permission_IFTable_fkey" FOREIGN KEY (
		"IFTable"
	) REFERENCES "CRD_Table" (
		"IDTable"
	)
GO
ALTER TABLE "CRD_Permission" CHECK CONSTRAINT "CRD_Permission_IFTable_fkey"
GO

ALTER TABLE "CRD_Permission" WITH CHECK 
	ADD CONSTRAINT "CRD_Permission_IFAction_fkey" FOREIGN KEY (
		"IFAction"
	) REFERENCES "CRD_Action" (
		"IDAction"
	)
GO
ALTER TABLE "CRD_Permission" CHECK CONSTRAINT "CRD_Permission_IFAction_fkey"
GO

ALTER TABLE "NET_Profile__default" WITH CHECK 
	ADD CONSTRAINT "NET_Profile__default_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "NET_Profile__default" CHECK CONSTRAINT "NET_Profile__default_IFProfile_fkey"
GO

ALTER TABLE "NET_BrowserUser" WITH CHECK 
	ADD CONSTRAINT "NET_BrowserUser_IFBrowser_fkey" FOREIGN KEY (
		"IFBrowser"
	) REFERENCES "NET_Browser" (
		"IDBrowser"
	)
GO
ALTER TABLE "NET_BrowserUser" CHECK CONSTRAINT "NET_BrowserUser_IFBrowser_fkey"
GO

ALTER TABLE "NET_BrowserUser" WITH CHECK 
	ADD CONSTRAINT "NET_BrowserUser_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NET_BrowserUser" CHECK CONSTRAINT "NET_BrowserUser_IFUser_fkey"
GO

ALTER TABLE "CRD_ProfileProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfileProfile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfileProfile" CHECK CONSTRAINT "CRD_ProfileProfile_IFProfile_fkey"
GO

ALTER TABLE "CRD_ProfileProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfileProfile_IFProfile_parent_fkey" FOREIGN KEY (
		"IFProfile_parent"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfileProfile" CHECK CONSTRAINT "CRD_ProfileProfile_IFProfile_parent_fkey"
GO

ALTER TABLE "CRD_Profile" WITH CHECK 
	ADD CONSTRAINT "CRD_Profile_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_Profile" CHECK CONSTRAINT "CRD_Profile_IFApplication_fkey"
GO

ALTER TABLE "CRD_UserProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_UserProfile_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "CRD_UserProfile" CHECK CONSTRAINT "CRD_UserProfile_IFUser_fkey"
GO

ALTER TABLE "CRD_UserProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_UserProfile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_UserProfile" CHECK CONSTRAINT "CRD_UserProfile_IFProfile_fkey"
GO

ALTER TABLE "DIC_User" WITH CHECK 
	ADD CONSTRAINT "DIC_User_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "DIC_User" CHECK CONSTRAINT "DIC_User_IFUser_fkey"
GO

ALTER TABLE "DIC_User" WITH CHECK 
	ADD CONSTRAINT "DIC_User_IFLanguage_fkey" FOREIGN KEY (
		"IFLanguage"
	) REFERENCES "DIC_Language" (
		"IDLanguage"
	)
GO
ALTER TABLE "DIC_User" CHECK CONSTRAINT "DIC_User_IFLanguage_fkey"
GO

ALTER TABLE "NET_User" WITH CHECK 
	ADD CONSTRAINT "NET_User_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "NET_User" CHECK CONSTRAINT "NET_User_IFUser_fkey"
GO

ALTER TABLE "NET_User" WITH CHECK 
	ADD CONSTRAINT "NET_User_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NET_User" CHECK CONSTRAINT "NET_User_IFApplication_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFTrigger_fkey" FOREIGN KEY (
		"IFTrigger"
	) REFERENCES "FRM_Trigger" (
		"IDTrigger"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFTrigger_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion__destination_fkey" FOREIGN KEY (
		"IFQuestion__destination"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion__destination_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFAnswer_fkey" FOREIGN KEY (
		"IFAnswer"
	) REFERENCES "FRM_Answer" (
		"IDAnswer"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFAnswer_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFQuestion_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFTrigger_fkey" FOREIGN KEY (
		"IFTrigger"
	) REFERENCES "FRM_Trigger" (
		"IDTrigger"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFTrigger_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_IFApplication_fkey"
GO

ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_TX_Description_fkey" FOREIGN KEY (
		"TX_Description"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_TX_Description_fkey"
GO

ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_TX_Name_fkey"
GO

ALTER TABLE "FRM_FormGroup" WITH CHECK 
	ADD CONSTRAINT "FRM_FormGroup_IFForm_fkey" FOREIGN KEY (
		"IFForm"
	) REFERENCES "FRM_Form" (
		"IDForm"
	)
GO
ALTER TABLE "FRM_FormGroup" CHECK CONSTRAINT "FRM_FormGroup_IFForm_fkey"
GO

ALTER TABLE "FRM_FormGroup" WITH CHECK 
	ADD CONSTRAINT "FRM_FormGroup_IFGroup_fkey" FOREIGN KEY (
		"IFGroup"
	) REFERENCES "FRM_Group" (
		"IDGroup"
	)
GO
ALTER TABLE "FRM_FormGroup" CHECK CONSTRAINT "FRM_FormGroup_IFGroup_fkey"
GO

ALTER TABLE "FRM_FormGroup" WITH CHECK 
	ADD CONSTRAINT "FRM_FormGroup_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_FormGroup" CHECK CONSTRAINT "FRM_FormGroup_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_QuestionAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionAnswer_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_QuestionAnswer" CHECK CONSTRAINT "FRM_QuestionAnswer_IFQuestion_fkey"
GO

ALTER TABLE "FRM_QuestionAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionAnswer_IFAnswer_fkey" FOREIGN KEY (
		"IFAnswer"
	) REFERENCES "FRM_Answer" (
		"IDAnswer"
	)
GO
ALTER TABLE "FRM_QuestionAnswer" CHECK CONSTRAINT "FRM_QuestionAnswer_IFAnswer_fkey"
GO

ALTER TABLE "FRM_QuestionAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionAnswer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_QuestionAnswer" CHECK CONSTRAINT "FRM_QuestionAnswer_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_GroupQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupQuestion_IFGroup_fkey" FOREIGN KEY (
		"IFGroup"
	) REFERENCES "FRM_Group" (
		"IDGroup"
	)
GO
ALTER TABLE "FRM_GroupQuestion" CHECK CONSTRAINT "FRM_GroupQuestion_IFGroup_fkey"
GO

ALTER TABLE "FRM_GroupQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupQuestion_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_GroupQuestion" CHECK CONSTRAINT "FRM_GroupQuestion_IFQuestion_fkey"
GO

ALTER TABLE "FRM_GroupQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupQuestion_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_GroupQuestion" CHECK CONSTRAINT "FRM_GroupQuestion_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_IFGroup__parent_fkey" FOREIGN KEY (
		"IFGroup__parent"
	) REFERENCES "FRM_Group" (
		"IDGroup"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_IFGroup__parent_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_IFApplication_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_TX_Title_fkey" FOREIGN KEY (
		"TX_Title"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_TX_Title_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_TX_Description_fkey" FOREIGN KEY (
		"TX_Description"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_TX_Description_fkey"
GO

ALTER TABLE "FRM_Question" WITH CHECK 
	ADD CONSTRAINT "FRM_Question_IFQuestion__parent_fkey" FOREIGN KEY (
		"IFQuestion__parent"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_Question" CHECK CONSTRAINT "FRM_Question_IFQuestion__parent_fkey"
GO

ALTER TABLE "FRM_Question" WITH CHECK 
	ADD CONSTRAINT "FRM_Question_IFQuestiontype_fkey" FOREIGN KEY (
		"IFQuestiontype"
	) REFERENCES "FRM_Questiontype" (
		"IDQuestiontype"
	)
GO
ALTER TABLE "FRM_Question" CHECK CONSTRAINT "FRM_Question_IFQuestiontype_fkey"
GO

ALTER TABLE "FRM_Question" WITH CHECK 
	ADD CONSTRAINT "FRM_Question_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FRM_Question" CHECK CONSTRAINT "FRM_Question_IFApplication_fkey"
GO

ALTER TABLE "FRM_Question" WITH CHECK 
	ADD CONSTRAINT "FRM_Question_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_Question" CHECK CONSTRAINT "FRM_Question_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Question" WITH CHECK 
	ADD CONSTRAINT "FRM_Question_TX_Question_fkey" FOREIGN KEY (
		"TX_Question"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Question" CHECK CONSTRAINT "FRM_Question_TX_Question_fkey"
GO

ALTER TABLE "FRM_Question" WITH CHECK 
	ADD CONSTRAINT "FRM_Question_TX_Details_fkey" FOREIGN KEY (
		"TX_Details"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Question" CHECK CONSTRAINT "FRM_Question_TX_Details_fkey"
GO

ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_IFApplication_fkey"
GO

ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_TX_Answer_fkey" FOREIGN KEY (
		"TX_Answer"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_TX_Answer_fkey"
GO

ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_TX_Details_fkey" FOREIGN KEY (
		"TX_Details"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_TX_Details_fkey"
GO

ALTER TABLE "FRM_UserQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_UserQuestion_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_UserQuestion" CHECK CONSTRAINT "FRM_UserQuestion_IFQuestion_fkey"
GO

ALTER TABLE "FRM_UserQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_UserQuestion_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserQuestion" CHECK CONSTRAINT "FRM_UserQuestion_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_UserQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_UserQuestion_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserQuestion" CHECK CONSTRAINT "FRM_UserQuestion_IFUser_fkey"
GO

ALTER TABLE "FRM_GroupAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupAnswer_IFGroup_fkey" FOREIGN KEY (
		"IFGroup"
	) REFERENCES "FRM_Group" (
		"IDGroup"
	)
GO
ALTER TABLE "FRM_GroupAnswer" CHECK CONSTRAINT "FRM_GroupAnswer_IFGroup_fkey"
GO

ALTER TABLE "FRM_GroupAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupAnswer_IFAnswer_fkey" FOREIGN KEY (
		"IFAnswer"
	) REFERENCES "FRM_Answer" (
		"IDAnswer"
	)
GO
ALTER TABLE "FRM_GroupAnswer" CHECK CONSTRAINT "FRM_GroupAnswer_IFAnswer_fkey"
GO

ALTER TABLE "FRM_GroupAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupAnswer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_GroupAnswer" CHECK CONSTRAINT "FRM_GroupAnswer_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_UserAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_UserAnswer_IFAnswer_fkey" FOREIGN KEY (
		"IFAnswer"
	) REFERENCES "FRM_Answer" (
		"IDAnswer"
	)
GO
ALTER TABLE "FRM_UserAnswer" CHECK CONSTRAINT "FRM_UserAnswer_IFAnswer_fkey"
GO

ALTER TABLE "FRM_UserAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_UserAnswer_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserAnswer" CHECK CONSTRAINT "FRM_UserAnswer_IFUser_fkey"
GO

ALTER TABLE "FRM_UserAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_UserAnswer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserAnswer" CHECK CONSTRAINT "FRM_UserAnswer_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_AnswerTrigger" WITH CHECK 
	ADD CONSTRAINT "FRM_AnswerTrigger_IFAnswer_fkey" FOREIGN KEY (
		"IFAnswer"
	) REFERENCES "FRM_Answer" (
		"IDAnswer"
	)
GO
ALTER TABLE "FRM_AnswerTrigger" CHECK CONSTRAINT "FRM_AnswerTrigger_IFAnswer_fkey"
GO

ALTER TABLE "FRM_AnswerTrigger" WITH CHECK 
	ADD CONSTRAINT "FRM_AnswerTrigger_IFTrigger_fkey" FOREIGN KEY (
		"IFTrigger"
	) REFERENCES "FRM_Trigger" (
		"IDTrigger"
	)
GO
ALTER TABLE "FRM_AnswerTrigger" CHECK CONSTRAINT "FRM_AnswerTrigger_IFTrigger_fkey"
GO

ALTER TABLE "FRM_AnswerTrigger" WITH CHECK 
	ADD CONSTRAINT "FRM_AnswerTrigger_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_AnswerTrigger" CHECK CONSTRAINT "FRM_AnswerTrigger_IFQuestion_fkey"
GO

ALTER TABLE "FRM_AnswerTrigger" WITH CHECK 
	ADD CONSTRAINT "FRM_AnswerTrigger_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_AnswerTrigger" CHECK CONSTRAINT "FRM_AnswerTrigger_IFUser__audit_fkey"
GO

