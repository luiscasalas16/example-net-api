# example-net-api

Proyectos de ejemplo de API en .Net Framework y .Net Core. En ambos se implementaron tres proyectos:
- api: un proyecto tipo web que implementa el API y tiene controladores de ejemplos y pruebas.
- api-client: un proyecto tipo consola que implementa la ejecuci�n de los ejemplos y pruebas en el API.
- api-utils: un proyecto tipo biblioteca de clases que implemente clases reutilizables para la implementaci�n del API.

Cada API implementa los siguientes requerimientos:
- Utilizan un manejo predeterminado de excepciones, por lo que no es necesario utilizar try-catch en cada m�todo.
- Implementan clases para resultados personalizados, con el objetivo de estandarizar las respuestas que puede tener el API, con el fin de estandarizar el c�digo fuente y facilitar a la aplicaci�n que lo consuma el manejo de las respuestas. Para facilitar el uso de las clases de resultados se implementaron m�todos de extensi�n para el controlador. El m�todo del controlador deber� utilizar c�mo tipo de retorno �Result�, que es la clase base y utilizar el m�todo extendido para el resultado correspondiente:
	- �this.ResultValid(�)�: Para retornar un resultado v�lido. Se retorna el c�digo 200.
	- �this.ResultInvalid(�)� Para retornar un error provocado por los par�metros utilizados en la invocaci�n del API. Se retorna el c�digo 400.
	- �this.ResultError(�)� Para retornar un error provocado por un problema a lo interno del API. Se retorna el c�digo 500.
    - Los resultados de error tienen c�mo respuesta estandarizada una respuesta de la forma:

```json
//resultado inv�lidos
{
    errores :
    [
        { mensaje : "identificaci�n es requerido" },
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