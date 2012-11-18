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

