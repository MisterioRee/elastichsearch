# Elasticsearch

 ![](/images/000000.png)

The architecture design for Elastic search includes number of machines (computers) that keeps an instance of Elastic, each machine contains one or many shards and the definition of shard is &quot;a group of documents&quot; where documents means data or records.

Things are not that simple, Elastic urge to make replica for each node so in-case of hardware failure Elastic uses the replica and the data us not lost. By the way Elastic manage this by self, to in dig-in more each node is existing 2 or more (as many we want) times in form of replica.

Also, each node can have many shards, shards will allow node to divide data into multiple classifications which will improve search terminology.

Note: the replica is managed by Elastic itself.



Below given example have 2 index, 2 nodes and 2 shards, each shard has replica on the other node so that in case of node failure the data isn&#39;t lost



##
![](/images/000001.png)

As we can see shards in node one denoted by 1. \* and 2. \* in node 2, have replicas in corresponding node, shards existing in node 2 have replicas in node 1 and shards in node 2 have replicas in node 2.

## Nodes Roles:

There are 3 type of role a node can perform

- Master role
- Data role
- Ingest role
- Machine learning role
- Coordination role
- Voting-only

### Master Node:

There is always one super power as the nature of the world, somewhat here there is also one node we can assign to keep managing shards and replicas and other processes that is going to help to keep cluster healthy, the master is chosen via voting. We can set a master by command If there is no other master. (Recommended for large clusters)

### Data Node:

Being an organizer, it would be hard for a node to do 2 jobs or either it will affect the performance, or you want to keep data organized, you can set some nodes to save data only.

### Ingest Role:

It enables a node to run ingest pipelines, which means a series of processes that should be performed while indexing a document e.g. applying conditions or resolving Ip addresses.

### Machine Learning Role:

Enable or disable machine learning of a specific document.

### Coordination Role:

It refers to distribution and aggregation of query result.

### Voting-Only Role:

It will involve in voting process but itself it can&#39;t be master, only useful for large clusters.

## Snapshots

Snapshots used as term backups, we can take a snapshot of a node and cluster at given time, it will save all the data of a node including state(s), in other words Snapshots are restore-points.

Why we need snapshots when we have replicas, the answer is it depends ☹, sometimes we have to switch the whole machine from a current time and state and sometime we just need the uptime in real-time scenarios.

## CRUD operations

List of Quires…

## Routing

To under how Elasticsearch fetch the data under the hood is based on routing. The store a specific document Elastic use a simple formula to calculate on which shard the document should be stored.

Shard\_num = hash(\_routing) % num\_primery\_shards

The same applies when we update and delete a document.

#### Custom routing

It is possible to change the default routing, using default routing it is very easy to work with but customizing routing come with benefits that we can store evenly the on each shard each document, or may 1 shard store more than the other one.

##### Other usage for custom routing

While creating the number of shards we specify the exact number of shards, if later we were to add more shards it can make mess or result into no document found while document is already there.

## Mapping

To be very simple it is the field types (Int, Text and bool etc..). Mapping can be done by elastic itself, while inserting data into elastic it will auto decide what type of this field is but also we can override that later but the cost of changing mapping or default mapping is rendering the whole cluster with update query. PUT index\_name/update\_by\_query?conflict=merge

### Meta fields

Before digging more into mapping understand the meta fields of a document that is added by Elasticsearch by default.

#### \_index

Contains the name of the index to which the document belongs.

#### \_id

Store the ID of document (if a document doesn&#39;t have id elastic will auto generate).

#### \_source

Contains the original JSON object used when indexing.

#### \_field\_names

Contains the name of every field that contains non-null value.

#### \_routing

Stores the value used to route a document to a shard.

#### \_version

Stores the internal version of a document (updates when document is updated).

#### \_meta

Store custom data that is not touched(index) by elasticsearch.

### Field data types

It can be further categories in 4 parts

1. Core data types
2. Complex data types
3. Geo Data types
4. Specialized data types

#### Core data types

Primitive data types as seem in normal programming languages e.g. strings, integers, dates, etc.

###### Text Data Type

Used to index full-text value such as description blog posts etc.

###### Keyword data type

Used for structured data (tags, categories, e-mail&#39;s), not analyzed. Typically used for filtering and aggregation.

###### Numeric Data Types

Used to store numeric values (int, double, byte and scaled\_float, etc)

###### Date

To store date (in string, long or int format)

###### Boolean Data type

To store Ture false values

###### Binary Data Type

Accepts a Base64 Encoded binary value. **Not stored by default**.

###### Range

Used for range between numeric values

{&quot;gte&quot;: 10, &quot;lte&quot;:20}

#### Complex data types

Complex primitives

###### Object Data Type

Added as JSON objects; stored as key-value pairs internally. May contains nested objects.

###### Array Data Type

Not an actual data type, because each field may contain multiple values by default.

###### Array of object

Array inside object.

###### Nested Data Type

Require nested quires

#### Geo Data Types

Accept latitude and longitude in 4 different formats, we can also calculate distance etc.

###### Geo-shape Data Type

Displays geographical shape of a stored object.

###### Specialized Data Types

Data type with very specific purpose such as Ip addresses.

###### IP data type

Used of IPV4 or IPV6

###### Completion Data Type

Used to provide auto completion and search suggestions functionality. It is optimized for quick lookups.

###### Attachment Data Type

Its is used to make text searchable, convert PDF, PPT etc searchable.

## Analyzer

Consist of tokenizer and filter perform various functionalities divided into many classifications.

### Standard Tokenizer Analyzer

It takes the text and divide using white spaces, e.g:

POST\_analyze

{

  &quot;tokenizer&quot;: &quot;standard&quot;,

  &quot;text&quot;: &quot;The 2 QUICK Brown-Foxes jumped over the lazy dog&#39;s bone.&quot;

}

[The,2, QUICK,Brown,Foxes, jumped, over, the, lazy, dog&#39;s, bone]

### Lower case filter

GET\_analyze

{

  &quot;tokenizer&quot;:&quot;standard&quot;,

  &quot;filter&quot;:[&quot;lowercase&quot;],

  &quot;text&quot;:&quot;THE Quick FoX JUMPs&quot;

}

[the, quick, fox, jumps]



## Search Methods

There are two methods to search from elasticsearch

- Query DSL

Query DSL Look alike JSON request via console or another request method

- Request URL (Query String Query)

It supports direct query via query parameters

GET index\_name/\_search?q=name:john

GET index\_name/\_search?q=name:john OR age:25

### Query DSL

Query DSL consist of leaf query and compound query, leaf query is **category = &#39;Fruit&#39;** while compound query is combination of leaf query

GET index\_name/\_search

{

  &quot;query&quot;: {

    &quot;match&quot;: {

      &quot;Key\_name&quot;: &quot;value to match&quot;

    }

  }

}