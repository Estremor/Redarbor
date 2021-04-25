# Redarbor
Api rest employee

1. Inserta un nuevo Employee con este json:

curl --location --request POST 'http://localhost:36862/api/Redarbor/' \
--header 'Content-Type: application/json' \
--data-raw '{
    "CompanyId": 1,
    "CreatedOn": "2000-01-01 00:00:00",
    "DeletedOn": "2000-01-01 00:00:00",
    "Email": "test1@test.test.tmp",
    "Fax": "000.000.000",
    "Name": "test1",
    "Lastlogin": "2000-01-01 00:00:00",
    "Password": "test",
    "PortalId": 1,
    "RoleId": 1,
    "StatusId": 1,
    "Telephone": "000.000.000",
    "UpdatedOn": "2000-01-01 00:00:00",
    "Username": "test1"
}'

2. Ejecuta la llamada GET para ver que está insertado
correctamente:
curl --location --request GET 'http://localhost:36862/api/Redarbor'

3. Ejecuta la llamada GET para ese id.
curl --location --request GET 'http://localhost:36862/api/Redarbor/1'

4. Modifica el registro insertado para que su usuario sea “test1updated”
curl --location --request PUT 'http://localhost:36862/api/Redarbor/1' \
--header 'Content-Type: application/json' \
--data-raw '{
    "CompanyId": 1,
    "CreatedOn": "2000-01-01 00:00:00",
    "DeletedOn": "2000-01-01 00:00:00",
    "Email": "test1@test.test.tmp",
    "Fax": "000.000.000",
    "Name": "test1",
    "Lastlogin": "2000-01-01 00:00:00",
    "Password": "test",
    "PortalId": 1,
    "RoleId": 1,
    "StatusId": 1,
    "Telephone": "000.000.000",
    "UpdatedOn": "2000-01-01 00:00:00",
    "Username": "test1updated"
}'

5. Verificar que se ha modificado.

curl --location --request GET 'http://localhost:36862/api/Redarbor/1'

6. Borrar el nuevo registro.
curl --location --request DELETE 'http://localhost:36862/api/Redarbor/1'

7. Comprobar que no existe.
curl --location --request GET 'http://localhost:36862/api/Redarbor/1'
