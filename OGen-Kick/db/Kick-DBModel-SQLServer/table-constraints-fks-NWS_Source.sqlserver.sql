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

