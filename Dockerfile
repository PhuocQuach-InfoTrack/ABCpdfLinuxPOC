
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
ENV LD_LIBRARY_PATH=/app
WORKDIR /src
COPY ["ABCpdfLinuxPOC.csproj", "."]
RUN dotnet restore "./ABCpdfLinuxPOC.csproj"
COPY . .
RUN dotnet publish ABCpdfLinuxPOC.csproj -r linux-x64 -c Release --self-contained false -o /app


FROM ubuntu.azurecr.io/ubuntu:22.04
ENV LD_LIBRARY_PATH=/app
RUN apt install zlib1g -y

RUN apt update && \
   apt install -y dotnet7

# For ABCChrome: libglib2.0-0 libatk1.0-0 libatk-bridge2.0-0
RUN apt install -y xserver-xorg-core --no-install-recommends --no-install-suggests

RUN apt install -y  libx11-dev libasound2 libnss3 libglib2.0-0 libcairo2 libatk1.0-0 libatk-bridge2.0-0 libcups2 libxcomposite1 libxdamage1 libxrandr2 libxkbcommon0 libpango-1.0-0 

# For ABCpdf
RUN apt update \
    && apt install -y --no-install-recommends \
        curl \
        libunwind8 \
        libc6 \
        libgcc-s1 \
        libstdc++6 \
        libicu70 \
    && rm -rf /var/lib/apt/lists/*


WORKDIR /app
ENV LD_LIBRARY_PATH=/app
COPY --from=builder /app ./

RUN chmod +x /app/ABCpdfLinuxPOC.dll
RUN chmod +x ABCChrome117/ABCChrome117

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "ABCpdfLinuxPOC.dll"]