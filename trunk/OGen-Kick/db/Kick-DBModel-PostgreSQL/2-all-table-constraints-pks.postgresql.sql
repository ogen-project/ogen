ALTER TABLE "CRD_User"
  ADD CONSTRAINT "CRD_User_pkey" PRIMARY KEY (
    "IDUser"
  )
;

ALTER TABLE "CRD_ProfilePermission"
  ADD CONSTRAINT "CRD_ProfilePermission_pkey" PRIMARY KEY (
    "IFProfile",
    "IFPermission"
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

ALTER TABLE "LOG_Type"
  ADD CONSTRAINT "LOG_Type_pkey" PRIMARY KEY (
    "IDType"
  )
;

ALTER TABLE "LOG_Error"
  ADD CONSTRAINT "LOG_Error_pkey" PRIMARY KEY (
    "IDError"
  )
;

ALTER TABLE "LOG_Log"
  ADD CONSTRAINT "LOG_Log_pkey" PRIMARY KEY (
    "IDLog"
  )
;

ALTER TABLE "CRD_Permission"
  ADD CONSTRAINT "CRD_Permission_pkey" PRIMARY KEY (
    "IDPermission"
  )
;

ALTER TABLE "NET_Profile__default"
  ADD CONSTRAINT "NET_Profile__default_pkey" PRIMARY KEY (
    "IFProfile"
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

ALTER TABLE "DIC_User"
  ADD CONSTRAINT "DIC_User_pkey" PRIMARY KEY (
    "IFUser"
  )
;

ALTER TABLE "APP_Application"
  ADD CONSTRAINT "APP_Application_pkey" PRIMARY KEY (
    "IDApplication"
  )
;

ALTER TABLE "NET_User"
  ADD CONSTRAINT "NET_User_pkey" PRIMARY KEY (
    "IFUser"
  )
;

ALTER TABLE "CRD_Table"
  ADD CONSTRAINT "CRD_Table_pkey" PRIMARY KEY (
    "IDTable"
  )
;

ALTER TABLE "CRD_Action"
  ADD CONSTRAINT "CRD_Action_pkey" PRIMARY KEY (
    "IDAction"
  )
;

ALTER TABLE "FRM_QuestionTriggerQuestion"
  ADD CONSTRAINT "FRM_QuestionTriggerQuestion_pkey" PRIMARY KEY (
    "IFQuestion",
    "IFTrigger",
    "IFQuestion__destination"
  )
;

ALTER TABLE "FRM_QuestionTriggerAnswer"
  ADD CONSTRAINT "FRM_QuestionTriggerAnswer_pkey" PRIMARY KEY (
    "IFQuestion",
    "IFTrigger",
    "IFAnswer"
  )
;

ALTER TABLE "FRM_Form"
  ADD CONSTRAINT "FRM_Form_pkey" PRIMARY KEY (
    "IDForm"
  )
;

ALTER TABLE "FRM_FormGroup"
  ADD CONSTRAINT "FRM_FormGroup_pkey" PRIMARY KEY (
    "IFForm",
    "IFGroup"
  )
;

ALTER TABLE "FRM_QuestionAnswer"
  ADD CONSTRAINT "FRM_QuestionAnswer_pkey" PRIMARY KEY (
    "IFQuestion",
    "IFAnswer"
  )
;

ALTER TABLE "FRM_GroupQuestion"
  ADD CONSTRAINT "FRM_GroupQuestion_pkey" PRIMARY KEY (
    "IFGroup",
    "IFQuestion"
  )
;

ALTER TABLE "FRM_Trigger"
  ADD CONSTRAINT "FRM_Trigger_pkey" PRIMARY KEY (
    "IDTrigger"
  )
;

ALTER TABLE "FRM_Group"
  ADD CONSTRAINT "FRM_Group_pkey" PRIMARY KEY (
    "IDGroup"
  )
;

ALTER TABLE "FRM_Question"
  ADD CONSTRAINT "FRM_Question_pkey" PRIMARY KEY (
    "IDQuestion"
  )
;

ALTER TABLE "FRM_Answer"
  ADD CONSTRAINT "FRM_Answer_pkey" PRIMARY KEY (
    "IDAnswer"
  )
;

ALTER TABLE "FRM_UserQuestion"
  ADD CONSTRAINT "FRM_UserQuestion_pkey" PRIMARY KEY (
    "IFUser",
    "IFQuestion"
  )
;

ALTER TABLE "FRM_GroupAnswer"
  ADD CONSTRAINT "FRM_GroupAnswer_pkey" PRIMARY KEY (
    "IFGroup",
    "IFAnswer"
  )
;

ALTER TABLE "FRM_Questiontype"
  ADD CONSTRAINT "FRM_Questiontype_pkey" PRIMARY KEY (
    "IDQuestiontype"
  )
;

ALTER TABLE "FRM_UserAnswer"
  ADD CONSTRAINT "FRM_UserAnswer_pkey" PRIMARY KEY (
    "IFUser",
    "IFAnswer"
  )
;

ALTER TABLE "FRM_AnswerTrigger"
  ADD CONSTRAINT "FRM_AnswerTrigger_pkey" PRIMARY KEY (
    "IFAnswer",
    "IFTrigger",
    "IFQuestion"
  )
;

