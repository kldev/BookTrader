### Project Book Trader

#### Used tools (optional):
- docker
- docker-compose

### Developer env (Linux/Mac machine)

- cd compose-dev
- sh run.sh


### Test env

- cd compose-test
- sh up.sh

### Demo env

- build docker image book.trader (sh buildFullDocker.sh)
- sh compose-demo-run/up.sh

### WebAPI Docs (Swagger-UI)

```
   https://localhost:5001/Docs

```

### Enviroment setup

configure application start to setup:
```
DEMO_AUTH=mJ1r6FGXBR7IsJp5fXqrunu5 
```

### End-to-End testing with httpie


- seed database 
```
http POST https://localhost:5001/api/demo/seed auth=mJ1r6FGXBR7IsJp5fXqrunu5 --verify=no
```

- list traders

```
http https://localhost:5001/api/trader/list --verify=no
```

- list trader books

Use Id of response list traders

```
http POST https://localhost:5001/api/book/list id=21de43462c074532b428872594c6d9e0 --verify=no
```

- create trader book

```
http POST https://localhost:5001/api/book/add traderId=21de43462c074532b428872594c6d9e0 author="New Author" title="New Title" price=5.24 --verify=no
```

- when no title return error 

```
http POST https://localhost:5001/api/book/add traderId=21de43462c074532b428872594c6d9e0 author="New Author" title="" price=5.24 --verify=no
```

- when no author return error 

```
http POST https://localhost:5001/api/book/add traderId=21de43462c074532b428872594c6d9e0 author="" title="New Title" price=5.24 --verify=no
```

- when no traderId return error 

```
http POST https://localhost:5001/api/book/add traderId= author="New Author" title="New Title" price=5.24 --verify=no
```

- return book by id

```
http POST https://localhost:5001/api/book/single id=681d20e4392047e6b7e8af1da76f73b8 --verify=no
```

- seed database (compose-demo-run)

```
http POST :8080/api/demo/seed auth=dockerAuth --verify=no
```

- list traders

```
http :8080/api/trader/list --verify=no
```