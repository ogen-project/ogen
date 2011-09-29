ALTER TABLE "APP_Application"
  ADD CONSTRAINT "APP_Application_pkey" PRIMARY KEY (
    "IDApplication"
  )
;

ALTER TABLE "CRD_User"
  ADD CONSTRAINT "CRD_User_pkey" PRIMARY KEY (
    "IDUser"
  )
;

ALTER TABLE "CRD_ProfilePermition"
  ADD CONSTRAINT "CRD_ProfilePermition_pkey" PRIMARY KEY (
    "IFProfile",
    "IFPermition"
  )
;

ALTER TABLE "DIC_Language"
  ADD CONSTRAINT "DIC_Language_pkey" PRIMARY KEY (
    "IDLanguage"
  )
;

ALTER TABLE "DIC_Text"
  ADD CONSTRAINT "DIC_Text_pkey" PRIMARY KEY (
    "IDText"
  )
;

ALTER TABLE "DIC_TextLanguage"
  ADD CONSTRAINT "DIC_TextLanguage_pkey" PRIMARY KEY (
    "IFText",
    "IFLanguage"
  )
;

ALTER TABLE "DIC_LanguageApplication"
  ADD CONSTRAINT "DIC_LanguageApplication_pkey" PRIMARY KEY (
    "IFLanguage",
    "IFApplication"
  )
;

ALTER TABLE "NWS_Attachment"
  ADD CONSTRAINT "NWS_Attachment_pkey" PRIMARY KEY (
    "IDAttachment"
  )
;

ALTER TABLE "NWS_ContentTag"
  ADD CONSTRAINT "NWS_ContentTag_pkey" PRIMARY KEY (
    "IFContent",
    "IFTag"
  )
;

ALTER TABLE "NWS_ContentSource"
  ADD CONSTRAINT "NWS_ContentSource_pkey" PRIMARY KEY (
    "IFContent",
    "IFSource"
  )
;

ALTER TABLE "NWS_ContentHighlight"
  ADD CONSTRAINT "NWS_ContentHighlight_pkey" PRIMARY KEY (
    "IFContent",
    "IFHighlight"
  )
;

ALTER TABLE "NWS_ContentAuthor"
  ADD CONSTRAINT "NWS_ContentAuthor_pkey" PRIMARY KEY (
    "IFContent",
    "IFAuthor"
  )
;

ALTER TABLE "NWS_Content"
  ADD CONSTRAINT "NWS_Content_pkey" PRIMARY KEY (
    "IDContent"
  )
;

ALTER TABLE "FOR_Message"
  ADD CONSTRAINT "FOR_Message_pkey" PRIMARY KEY (
    "IDMessage"
  )
;

ALTER TABLE "NWS_Source"
  ADD CONSTRAINT "NWS_Source_pkey" PRIMARY KEY (
    "IDSource"
  )
;

ALTER TABLE "NWS_Highlight"
  ADD CONSTRAINT "NWS_Highlight_pkey" PRIMARY KEY (
    "IDHighlight"
  )
;

ALTER TABLE "NWS_Author"
  ADD CONSTRAINT "NWS_Author_pkey" PRIMARY KEY (
    "IDAuthor"
  )
;

ALTER TABLE "NWS_Tag"
  ADD CONSTRAINT "NWS_Tag_pkey" PRIMARY KEY (
    "IDTag"
  )
;

ALTER TABLE "NWS_ContentProfile"
  ADD CONSTRAINT "NWS_ContentProfile_pkey" PRIMARY KEY (
    "IFContent",
    "IFProfile"
  )
;

ALTER TABLE "NWS_Profile"
  ADD CONSTRAINT "NWS_Profile_pkey" PRIMARY KEY (
    "IFProfile"
  )
;

ALTER TABLE "NWS_UserTag"
  ADD CONSTRAINT "NWS_UserTag_pkey" PRIMARY KEY (
    "IFUser",
    "IFTag"
  )
;

ALTER TABLE "LOG_Logtype"
  ADD CONSTRAINT "LOG_Logtype_pkey" PRIMARY KEY (
    "IDLogtype"
  )
;

ALTER TABLE "LOG_Errortype"
  ADD CONSTRAINT "LOG_Errortype_pkey" PRIMARY KEY (
    "IDErrortype"
  )
;

ALTER TABLE "LOG_Log"
  ADD CONSTRAINT "LOG_Log_pkey" PRIMARY KEY (
    "IDLog"
  )
;

ALTER TABLE "CRD_Permition"
  ADD CONSTRAINT "CRD_Permition_pkey" PRIMARY KEY (
    "IDPermition"
  )
;

ALTER TABLE "NET_Defaultprofile"
  ADD CONSTRAINT "NET_Defaultprofile_pkey" PRIMARY KEY (
    "IDDefaultprofile"
  )
;

ALTER TABLE "NET_Browser"
  ADD CONSTRAINT "NET_Browser_pkey" PRIMARY KEY (
    "IDBrowser"
  )
;

ALTER TABLE "NET_BrowserUser"
  ADD CONSTRAINT "NET_BrowserUser_pkey" PRIMARY KEY (
    "IFBrowser",
    "IFUser"
  )
;

ALTER TABLE "CRD_ProfileProfile"
  ADD CONSTRAINT "CRD_ProfileProfile_pkey" PRIMARY KEY (
    "IFProfile",
    "IFProfile_parent"
  )
;

ALTER TABLE "CRD_Profile"
  ADD CONSTRAINT "CRD_Profile_pkey" PRIMARY KEY (
    "IDProfile"
  )
;

ALTER TABLE "CRD_UserProfile"
  ADD CONSTRAINT "CRD_UserProfile_pkey" PRIMARY KEY (
    "IFUser",
    "IFProfile"
  )
;

ALTER TABLE "NET_User"
  ADD CONSTRAINT "NET_User_pkey" PRIMARY KEY (
    "IFUser"
  )
;

