
<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# Consigna proyecto 2024 2º semestre

<br>

Este semestre, desarrollaremos... ¡chatbots! 🤖

![Bender](https://media.giphy.com/media/mIZ9rPeMKefm0/giphy.gif)

## Contexto

Un chatbot o [bot conversacional](https://es.wikipedia.org/wiki/Bot_conversacional)
es un programa que simula mantener una conversación con una persona al proveer
respuestas automáticas a entradas hechas por el usuario.

Existen gran variedad de chatbots actualmente y varios *sabores*. Hay chatbots
que simplemente responden a comandos pre-establecidos, y otros que integran
algoritmos de [inteligencia artificial](https://es.wikipedia.org/wiki/Inteligencia_artificial)
para procesar los mensajes de los usuarios e [interpretar lo que se está diciendo](https://es.wikipedia.org/wiki/Procesamiento_de_lenguajes_naturales).

Algunas de las aplicaciones más conocidas que abren sus puertas al desarrollo de
chatbots —tienen API— son:

* Telegram
* Messenger
* Whatsapp
* Slack
* Discord

entre otras; y nos integraremos al menos a una de ellas.

## Roadmap

El proyecto se divide en varias entregas a lo largo del semestre, que se
detallan [más abajo](#entregas).

Cada entrega es una parte del proyecto que construye sobre la anterior. Al final
del semestre tendremos un conjunto de chatbots funcionales con los que podremos
conversar.

El chatbot a desarrollar será propuesto por los estudiantes, según se indica en
la sección [Propuestas](#propuestas).

La estructura del trabajo en el proyecto será la siguiente:

* [x] Kick-off
* [x] Presentación de propuestas
* [x] Evaluación docente de propuestas
* [x] Votación de propuestas
* [x] Lanzamiento de la propuesta elegida
* [ ] Primera entrega
* [ ] Segunda entrega
* [ ] Entrega final
* [ ] Defensa

## Propuestas

Los equipos o sus integrantes podrán a presentar propuestas de chatbots para
desarrollar. El chatbot debe permitir un juego interactivo multijugador —por
turnos— de al menos dos jugadores, que no requiera de una interfaz gráfica, es
decir, las jugadas se describen mediante un mensaje como en el ajedrez o la
batalla naval.

Utiliza [este formulario](https://forms.office.com/r/yG6UeqJWRx) para enviar tus
propustas. ¡Pueden enviar todas las propuestas que quieran!

Puedes ver la fecha límite para entrega de propuestas en la sección
[Entregas](#entregas).

## Resultados
<img alt="Resultados de votación" src="./Assets/results.png"/>


## Historias de usuario

### 1. Como **jugador**, quiero elegir 6 Pokémons del catálogo disponible para comenzar la batalla.
- **Criterios de aceptación:**
  - El jugador puede seleccionar 6 Pokémons de una lista o catálogo.
  - Los Pokémons seleccionados se muestran en la pantalla del jugador.

### 2. Como **jugador**, quiero ver los ataques disponibles de mis Pokémons para poder elegir cuál usar en cada turno.
- **Criterios de aceptación:**
  - Se muestran los ataques disponibles para el turno actual.
  - Los ataques especiales solo pueden seleccionarse cada dos turnos.

### 3. Como **jugador**, quiero ver la cantidad de vida (HP) de mis Pokémons y de los Pokémons oponentes para saber cuánta salud tienen.
- **Criterios de aceptación:**
  - La vida de los Pokémons propios y del oponente se actualizan tras cada ataque.
  - La vida se muestra en formato numérico (ej. 20/50).

### 4. Como **jugador**, quiero atacar en mi turno y hacer daño basado en la efectividad de los tipos de Pokémon.
- **Criterios de aceptación:**
  - El jugador puede seleccionar un ataque que inflige daño basado en la efectividad de tipos.
  - El sistema aplica automáticamente la ventaja o desventaja del tipo de ataque.

### 5. Como **jugador**, quiero saber de quién es el turno para estar seguro de cuándo atacar o esperar.
- **Criterios de aceptación:**
  - En la pantalla se muestra claramente un indicador que señala de quién es el turno actual.

### 6. Como **jugador**, quiero ganar la batalla cuando la vida de todos los Pokémons oponente llegue a cero.
- **Criterios de aceptación:**
  - La batalla termina automáticamente cuando todos los Pokémons del oponente alcanza 0 de vida.
  - Se muestra un mensaje indicando el ganador de la batalla.

### 7. Como **jugador**, quiero poder cambiar de Pokémon durante una batalla.
- **Criterios de aceptación:**
  - Al cambiar de Pokémon se pierde el turno

## Entregas

<!-- Los equipos deberán utilizar los repos asignados a los equipos. La URL de los repos tiene la forma <https://github.com/ucudal/PII_2023_2_equipo_X> donde X es el número del equipo.

Para su proyecto deberán usar la plantilla provista en [este repo](https://github.com/ucudal/PII_ProjectTemplate). Esa plantilla ya tiene la estructura de carpetas y la configuración correcta para el proyecto.

Cada entrega tendrá una consigna en particular cuya letra se liberará en la siguiente clase a la entrega anterior.

En cada instancia el equipo docente realizará una evaluación del código y todos los demás entregables que correspondan y le devolverá una calificación acompañada de feedback a cada equipo.

En la evaluación y el feedback se hará especial énfasis a lo que se pide en la consigna de la entrega, pero de igual manera pueden hacer cambios (y los alentamos a que así sea) en el código de entregas anteriores. Los entregables no son artefactos estáticos; deben evolucionar a lo largo del ciclo de desarrollo.

La entregas podrán estar acompañadas además de una tarea de evaluación entre pares (*peer review*). -->

> [!WARNING]
> **Importante:** Las entregas serán hasta las 23:59 del día indicado.

| Instancia | Fecha | Entregables |
| --- | --- | --- |
| Kick-off | 2 al 4 de setiembre, primera clase de la semana 5 | |
| Presentación de propuestas | Hasta el 7 de setiembre | Completar [este formulario](https://forms.office.com/r/yG6UeqJWRx) |
| Evaluación docente de propuestas | 7 al 11 de setiembre | |
| Votación de propuestas | 11 al 13 de setiembre | |
| Lanzamiento de proyectos | 16 a 19 de setiembre, primera clase de la semana 7 | |
| [Primera entrega](./Entregas/Entrega1.md) | 11 de octubre | Tarjetas CRC, diagrama de clases, código de clases de dominio + [fachada](https://refactoring.guru/design-patterns/facade) |
| [Segunda entrega](./Entregas/Entrega2.md) | 8 de noviembre | Entrega de [user stories](https://es.wikipedia.org/wiki/Historias_de_usuario) implementadas. Las historias de usuario deberán ser implementadas mediante [casos de prueba](https://en.wikipedia.org/wiki/Test_case) usando la fachada. |
| [Entrega final](./Entregas/Entrega3.md) | 26 de noviembre | Bot funcionando y entregables según se indica en la [consigna de la entrega](./Entregas/Entrega3.md) |
| Defensa | 27 al 29 de noviembre |
