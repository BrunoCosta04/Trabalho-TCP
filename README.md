# Trabalho-TCP
Trabalho de Técnicas de Construção de Programas na Universidade Federal do rio Grande do Sul semestre 2023/2.
Este trabalho utiliza as técnologias (...tecs) e a cadeira foca na necessidade da utilização da programação orientada a objeto com objetivo de desenvolver código com melhor qualidade, como expressado no livro base da disciplina Software Quality. 

#Especificação do Trabalho








| Texto | Informação Musical ou Ação |
| --- | --- |
| (Letra A maiúscula) | `Nota Lá`|
| (Letra B maiúscula) | `Nota Sí`|
| (Letra C maiúscula) | `Nota Dó`|
| (Letra D maiúscula) | `Nota Ré`|
| (Letra E maiúscula) | `Nota Mi`|
| (Letra F maiúscula) | `Nota Fá`|
| (Letra G maiúscula) | `Nota Sol`|
| Letras a,b,c,d,e,f,g minúsculas |**Se caractere anterior era NOTA (A a G), repete nota; Caso contrário, Silêncio ou pausa**|
| Caractere Espaço | **Aumenta volume para o DOBRO do volume; Se não puder aumentar, volta ao volume default (de início)**|
| Caractere ! (ponto de exclamação) | Trocar instrumento para o instrumento General MIDI #114 (Agogo)|
| Qualquer outra letra vogal (O ou o, I ou i , U ou u) | Trocar instrumento para o instrumento General MIDI (Harpsichord) |
| Qualquer outra letra consoante(todas consoantes exceto as que são notas)| **Se caractere anterior era NOTA (A a G),repete nota; Caso contrário, Silêncio ou pausa**|
|Dígito par ou impar|**Trocar instrumento para o instrumento General MIDI cujo numero é igual ao valor do instrumento ATUAL + valor do dígito**|
| Caractere ? (ponto dev interrogação) e caractere .(ponto)|**Aumenta UMA oitava; Se não puder, aumentar, volta à oitava default (de início)**|
| Caractere NL (nova linha)  |**Trocar instrumento para o instrumentoGeneral MIDI #15 (Tubular Bells)**|
| Caractere ; (ponto e vírgula) |**Trocar instrumento para o instrumentoGeneral MIDI #76 (Pan Flute)**|
| Caractere , (vírgula) |**Trocar instrumento para o instrumento General MIDI #20 (Church Organ)**|
| ELSE (nenhum dos caracteres anteriores) |**Se caractere anterior era NOTA (A a G), repete nota; Caso contrário, Silêncio ou pausa**|








