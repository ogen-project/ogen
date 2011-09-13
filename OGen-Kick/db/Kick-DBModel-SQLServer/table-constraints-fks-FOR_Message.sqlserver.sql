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

