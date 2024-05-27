Tool which creates an executable project which can be installed as a Windows NT Service and also run as a console appliction.

Once the project has been created, add the actual logic in ActualStart and ActualStop methods.

Once the service project compiles, below are the command line parameters available.

/install To install as a windows NT Service
/uninstall To uninstall from Windows NT service
/console To run the executable as a console application or to debug from visual studio, plass this parameter.
