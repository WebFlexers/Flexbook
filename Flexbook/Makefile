# Project Variables

PROJECT_NAME ?= Flexbook

.PHONY: migrations db

add_migration:
	cd ./Flexbook.Data && dotnet ef --startup-project ../Flexbook.Web/ migrations add $(mname) && cd ..

remove_migration:
	cd ./Flexbook.Data && dotnet ef --startup-project ../Flexbook.Web/ migrations remove && cd ..

update_db:
	cd ./Flexbook.Data && dotnet ef --startup-project ../Flexbook.Web/ database update && cd ..
