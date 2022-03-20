FROM postgres:14.2-alpine

ENV POSTGRES_DB notas
ENV POSTGRES_USER professor
ENV POSTGRES_PASSWORD fiap1234

COPY CreateDB.sql /docker-entrypoint-initdb.d/

EXPOSE 5432