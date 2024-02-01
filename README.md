
# ABCpdfLinuxPOC Dockerized Application

This repository contains the Dockerfile and source code for ABCpdfLinuxPOC, a .NET application. The Dockerfile is designed to build and run the application within a Docker container.

## Dockerfile Overview

The Dockerfile is divided into several stages:

### Build Stage (builder)

- The official .NET SDK 7.0 image is used.
- The `LD_LIBRARY_PATH` environment variable is set.
- The application is restored, built, and published to the `/app` directory.

### Final Stage

- The base image is set to Ubuntu 22.04.
- Additional dependencies and libraries are installed for ABCChrome and ABCpdf.
- The published application files are copied from the build stage.
- File permissions are adjusted.
- The ASP.NET Core URLs are configured to listen on port 8080.
- The entry point is set to run the `ABCpdfLinuxPOC.dll` application.


### Build and Run

1. Open a terminal in the project root directory.

2. Run the following command to build and start the services:

    ```bash
    docker-compose build
    docker-compose up
    ```

3. If application started successfully, there will be a PDF file at ./app-data folder
4. Access the application at http://localhost:8080/swagger/index.html or using HttpClient to reach HTTPPOSt http://localhost:8080/pdf to create pdf from html site (1st page only)

   Some html page links for test:
   - https://www.w3schools.com/html/html_colors.asp
   - https://www.google.com/
   - https://www.google.com/imghp?hl=en&ogbl
