# Nuget 빌드 자동스크립트 Doc


## Step1 : 닷넷 빌드

  dotnet restore Src/LineDevelopers/LineDevelopers.csproj

  dotnet build Src/LineDevelopers/LineDevelopers.csproj --configuration Release --no-restore


## Step2 : Nuget Push

  dotnet nuget push Src/LineDevelopers/bin/Release/LineDevelopers.1.0.0.nupkg -k ${{ secrets.NUGET_PUBLIC }} --source "https://api.nuget.org/v3/index.json"


## Nuget 키 등록방법

경로 : Project - Setting - Secrets and variables 

Name : NUGET_PUBLIC

|Name|Secret|
|NUGET_PUBLIC|Your Key|


## 태깅규칙

 v1.0.0 과 같이 Gthub 태깅을 딸때 작동되며, 해당버전은 NUGET 패키지버전과 일치가 됩니다. 

 닷넷빌드의 버전과 일치가 되게됨으로 , 태깅을 따기전 빌드의 버전을 맞춰주세요


|태깅버전|바이너리버전|
|v1.0.0|1.0.0|
