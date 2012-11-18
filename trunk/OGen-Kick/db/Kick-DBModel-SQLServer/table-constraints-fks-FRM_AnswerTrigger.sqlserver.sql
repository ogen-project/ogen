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

