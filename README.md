# example-net-api

Proyectos de ejemplo de API en .Net Framework y .Net Core. En ambos se implementaron tres proyectos:
- api: un proyecto tipo web que implementa el API y tiene controladores de ejemplos y pruebas.
- api-client: un proyecto tipo consola que implementa la ejecución de los ejemplos y pruebas en el API.
- api-utils: un proyecto tipo biblioteca de clases que implemente clases reutilizables para la implementación del API.

Cada API implementa los siguientes requerimientos:
- Utilizan un manejo predeterminado de excepciones, por lo que no es necesario utilizar try-catch en cada método.
- Implementan clases para resultados personalizados, con el objetivo de estandarizar las respuestas que puede tener el API, con el fin de estandarizar el código fuente y facilitar a la aplicación que lo consuma el manejo de las respuestas. Para facilitar el uso de las clases de resultados se implementaron métodos de extensión para el controlador. El método del controlador deberá utilizar cómo tipo de retorno “Result”, que es la clase base y utilizar el método extendido para el resultado correspondiente:
	- “this.ResultValid(…)”: Para retornar un resultado válido. Se retorna el código 200.
	- “this.ResultInvalid(…)” Para retornar un error provocado por los parámetros utilizados en la invocación del API. Se retorna el código 400.
	- “this.ResultError(…)” Para retornar un error provocado por un problema a lo interno del API. Se retorna el código 500.
    - Los resultados de error tienen cómo respuesta estandarizada una respuesta de la forma:

```json
//resultado inválidos
{
    errores :
    [
        { mensaje : "identificación es requerido" },
        { mensaje : "nombre es requerido" }
    ]
}

//resultado error
{
    errores :
    [
        { mensaje : "internal api error" }
    ]
}
```

    - x

Cada API implementa los siguientes ejemplos y pruebas:
- x
- y