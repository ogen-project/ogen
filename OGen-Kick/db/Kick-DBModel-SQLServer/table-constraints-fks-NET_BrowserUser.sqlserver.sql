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

