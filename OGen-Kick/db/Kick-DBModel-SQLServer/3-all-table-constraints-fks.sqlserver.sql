ALTER TABLE "CRD_User" WITH CHECK 
	ADD CONSTRAINT "CRD_User_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_User" CHECK CONSTRAINT "CRD_User_IFApplication_fkey"
GO

ALTER TABLE "CRD_ProfilePermition" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermition_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfilePermition" CHECK CONSTRAINT "CRD_ProfilePermition_IFProfile_fkey"
GO

ALTER TABLE "CRD_ProfilePermition" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermition_IFPermition_fkey" FOREIGN KEY (
		"IFPermition"
	) REFERENCES "CRD_Permition" (
		"IDPermition"
	)
GO
ALTER TABLE "CRD_ProfilePermition" CHECK CONSTRAINT "CRD_ProfilePermition_IFPermition_fkey"
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
	ADD CONSTRAINT "NWS_Content_tx_summary_fkey" FOREIGN KEY (
		"tx_summary"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_tx_summary_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_tx_subtitle_fkey" FOREIGN KEY (
		"tx_subtitle"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_tx_subtitle_fkey"
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
	ADD CONSTRAINT "NWS_Content_IFUser__Aproved_fkey" FOREIGN KEY (
		"IFUser__Aproved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_IFUser__Aproved_fkey"
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

ALTER TABLE "LOG_Logtype" WITH CHECK 
	ADD CONSTRAINT "LOG_Logtype_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Logtype" CHECK CONSTRAINT "LOG_Logtype_IFApplication_fkey"
GO

ALTER TABLE "LOG_Logtype" WITH CHECK 
	ADD CONSTRAINT "LOG_Logtype_IFLogtype_parent_fkey" FOREIGN KEY (
		"IFLogtype_parent"
	) REFERENCES "LOG_Logtype" (
		"IDLogtype"
	)
GO
ALTER TABLE "LOG_Logtype" CHECK CONSTRAINT "LOG_Logtype_IFLogtype_parent_fkey"
GO

ALTER TABLE "LOG_Errortype" WITH CHECK 
	ADD CONSTRAINT "LOG_Errortype_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Errortype" CHECK CONSTRAINT "LOG_Errortype_IFApplication_fkey"
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
	ADD CONSTRAINT "LOG_Log_IFPermition_fkey" FOREIGN KEY (
		"IFPermition"
	) REFERENCES "CRD_Permition" (
		"IDPermition"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFPermition_fkey"
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
	ADD CONSTRAINT "LOG_Log_IFLogtype_fkey" FOREIGN KEY (
		"IFLogtype"
	) REFERENCES "LOG_Logtype" (
		"IDLogtype"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFLogtype_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFErrortype_fkey" FOREIGN KEY (
		"IFErrortype"
	) REFERENCES "LOG_Errortype" (
		"IDErrortype"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFErrortype_fkey"
GO

ALTER TABLE "CRD_Permition" WITH CHECK 
	ADD CONSTRAINT "CRD_Permition_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_Permition" CHECK CONSTRAINT "CRD_Permition_IFApplication_fkey"
GO

ALTER TABLE "NET_Defaultprofile" WITH CHECK 
	ADD CONSTRAINT "NET_Defaultprofile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "NET_Defaultprofile" CHECK CONSTRAINT "NET_Defaultprofile_IFProfile_fkey"
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

