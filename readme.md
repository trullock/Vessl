# Vessl SSL Exporter

Exports all the SSL Certificates from your Local Machine as Pkcs12

## Why

Because you can't be bothered to do them all by hand from `mmc`.

## Usage

`Vessl [options] <Export Path>`

`Export Path` can be an absolute or relative path.

Optional Switches

`/f=<stringformat>` - {0} is the expiry datetime, {1} is the hostname of the cert.

e.g. `/f={0:yyyyMMddHHmmss}-{1}`


`/p=<password>` - Specify a password for the exported certificates.

e.g. `/p=secret`


### Complete Example

`Vessl /f={0:yyyyMMddHHmmss}-{1} /p=secret d:\ssl-export`