
 public class MyElasticsearch
    {
        public Uri node = new Uri("http://IP_TO_THE_NODE:9200");
        private ConnectionSettings settings { get; }
        private ElasticClient client { get; }

        public MyElasticsearch ( )
        {
            this.settings = new ConnectionSettings ( node )
                .RequestTimeout ( TimeSpan.FromMinutes ( 2 ) )
                .DefaultIndex ( "index_name" );
            this.client = new ElasticClient ( settings );
        }

        public dynamic search ( )
        {
            var searchResponse = client.Search<RequestModel>(s => s
                .Query(q => q
                    .Match( m => m.Field(f=>f.CurrencyCode)                   
                    )
                )
            );

            return searchResponse;
        }

    }