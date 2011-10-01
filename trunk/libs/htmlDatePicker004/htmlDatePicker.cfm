<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" 
    "http://www.w3.org/TR/html4/loose.dtd">

<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<title>htmlDatePicker Test Page (CFML)</title>
	<script language="JavaScript" src="htmlDatePicker.js" type="text/javascript"></script>
	<link href="htmlDatePicker.css" rel="stylesheet">
</head>

<body>
<cfif IsDefined("form.SelectedDate")>
	<p>You selected the date: <cfoutput>#form.SelectedDate# (#DateFormat(form.SelectedDate,"mmmm dd, yyyy")#)</cfoutput></p>
</cfif>
<form action="datepicker.cfm" method="post" name="frmMain" id="frmMain">
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
	Please select a date: 
	<script language="javascript">
		DisablePast = false;
		range_start = new Date(2006,11-1,8);
		range_end = new Date(2006,11-1,5);
	</script>
	<input type="text" value="Click me!" name="SelectedDate" id="SelectedDate" readonly onClick="GetDate(this);">
	<br>
	<input type="submit">
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
</form>
</body>
</html>
