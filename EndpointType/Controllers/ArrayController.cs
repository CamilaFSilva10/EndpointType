using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Text.Json;

namespace EndpointType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase
    {
        //Tamanho fixo, unidimensional
        [HttpGet("simples")]
        public IActionResult GetSimpleArray()
        {
            int[] simpleArray = { 1, 2, 3, 4, 5 };
            return Ok(simpleArray);
        }

        //Matriz (2D, 3D, etc)
        [HttpGet("multidimensional")]
        public IActionResult GetMultidimensionalArray()
        {
            int[,] arrayMultidimensional = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var list = new List<int[]>();
            for (int i = 0; i < arrayMultidimensional.GetLength(0); i++)
            {
                int[] row = new int[arrayMultidimensional.GetLength(1)];
                for (int j = 0; j < arrayMultidimensional.GetLength(1); j++)
                {
                    row[j] = arrayMultidimensional[i, j];
                }
                list.Add(row);
            }

            // Serializando
            string json = JsonSerializer.Serialize(list, options);

            return Ok(json);
        }

        //Array de arrays, tamanho variavel por linha
        [HttpGet("jagged")]
        public IActionResult GetJaggedArray()
        {
            int[][] jaggedArray = new int[3][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6 }
            };
            return Ok(jaggedArray);
        }

        //Manipulação eficiente da memória sem alocação extras
        [HttpGet("span")]
        public IActionResult GetSpan()
        {
            Span<int> span = stackalloc int[5];
            for (int i = 0; i < 5; i++)
            {
                span[i] = i + 1;
            }
            return Ok(span.ToArray());
        }

        //Similar ao Span<T> mas pode ser armazenado em classes
        [HttpGet("memory")]
        public IActionResult GetMemory()
        {
            Memory<int> memory = new int[5];
            for (int i = 0; i < 5; i++)
            {
                memory.Span[i] = i + 1;
            }
            return Ok(memory.ToArray());
        }

        //Similar ao Span<T> mas somente leitura
        [HttpGet("readonlyspan")]
        public IActionResult GetReadOnlySpan()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            ReadOnlySpan<int> readOnlySpan = array.AsSpan().Slice(1, 3);
            return Ok(readOnlySpan.ToArray());
        }

        //Array imutavel, seguro para concorrência
        [HttpGet("immutable")]
        public IActionResult GetImmutableArray()
        {
            ImmutableArray<int> immutableArray = ImmutableArray.Create(1, 2, 3, 4, 5);
            return Ok(immutableArray);
        }

        //Array dinâmico, não genérico
        [HttpGet("arraylist")]
        public IActionResult GetArrayList()
        {
            ArrayList arrayList = new ArrayList() { 1, "two", 3.0 };
            return Ok(arrayList);
        }

        //Lista genérica flexível
        [HttpGet("list")]
        public IActionResult GetList()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            return Ok(list);
        }

        //Conjunto de valores únicos
        [HttpGet("hashset")]
        public IActionResult GetHashSet()
        {
            HashSet<int> hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };
            return Ok(hashSet);
        }

        //Fila (FIFO - Primeiro a entrar, Primeiro a sair)
        [HttpGet("queue")]
        public IActionResult GetQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            return Ok(queue);
        }

        //Pilha (LIFO - Último a entrar, Primeiro a sair)
        [HttpGet("stack")]
        public IActionResult GetStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            return Ok(stack);
        }

        //Coleção para acesso concorrente
        [HttpGet("concurrentbag")]
        public IActionResult GetConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            return Ok(bag);
        }

        //Buffer fixo, usado em código unsafe
        [HttpGet("fixedsizebuffer")]
        public IActionResult GetFixedSizeBuffer()
        {
            Span<int> buffer = stackalloc int[3];
            buffer[0] = 1;
            buffer[1] = 2;
            buffer[2] = 3;
            return Ok(buffer.ToArray());
        }

        //Array nativo para Unity
        [HttpGet("nativearray")]
        public IActionResult GetNativeArray()
        {
            //Para utilizar é necessário um projeto Unity
            //No contexto .NET puro, a estrutura NativeArray<T> não existe
            //Exemplo de como seria em um projeto Unity a seguir:
            /*NativeArray<int> nativeArray = new NativeArray<int>(5, Allocator.Temp);
            for (int i = 0; i < 5; i++)
            {
                nativeArray[i] = i + 1;
            }
            return Ok(nativeArray);*/
            return Ok();
        }

    }
}
