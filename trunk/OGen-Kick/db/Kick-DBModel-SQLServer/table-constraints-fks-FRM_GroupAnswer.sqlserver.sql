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

