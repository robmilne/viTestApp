viTestApp README

viTestApp is a Windows .NET application to test the functionality of fuzzy servo
controllers created by Vera Ikona.  The software is intended for users to test
servo controllers using a Windows platform in combination with the USB to CAN
gateway device.  The project source is provided as a guide to users who wish to
create their own custom Windows applications using the viServoMaster dll
provided by Vera Ikona.

The software was written in Microsoft Visual C# within Microsoft Visual Studio
2008.  The target framework is .NET framework 3.5.

Dependencies:
FTD2XX_NET.dll available from FTDI
http://www.ftdichip.com/Drivers/D2XX.htm

viServoMaster.dll available from Vera Ikona


/******************************************************************************/
Installation and Operation:

1/Download and install the FTDI D2XX driver for your OS version from:
  http://www.ftdichip.com/Drivers/D2XX.htm

2/Download and run viTestAppInstaller.exe to install the software.

3/Attach the servo controllers to the gateway via CAN cable.  Power up the servo
  controllers.

3/Attach the USB to CAN Gateway to the computer and let the driver recognize
  the device.

4/Start the application and select 'Open Servo Network' to open the
  'Select Gateway' form.  The serial number of the FTDI FIFO chip should appear
  in the combobox.

5/Click the 'Open FTDI Device' button to begin communication with the gateway
  and the servo network.  Initial detection of the servo network will take
  approximately 6 seconds if the small network (ids less than 5) is not selected.

6/An error will be displayed if any servo modules are uninitialized (no hardware
  configuration stored in their respective eeproms).  After setting the servo hw
  configuration the controller is ready to accept motion control commands.


Kind regards,
-rob