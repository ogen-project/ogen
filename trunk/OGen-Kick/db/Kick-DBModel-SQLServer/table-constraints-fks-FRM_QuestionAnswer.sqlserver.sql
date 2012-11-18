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

