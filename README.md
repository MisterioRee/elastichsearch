# Elasticsearch 
The architecture design for Elastic search includes number of machines (computers) that keeps an instance of Elastic, each machine contains one or many shards and the definition of shard is “a group of documents” where documents means data or records.

![Fig ](/images/000000.png)

Things are not that simple, Elastic urge to make replica for each node so in-case of hardware failure Elastic uses the replica and the data us not lost. By the way Elastic manage this by self, to in dig-in more each node is existing 2 or more (as many we want) times in form of replica.
Also, each node can have many shards, shards will allow node to divide data into multiple classifications which will improve search terminology.
*Note: the replica is managed by Elastic itself.

--------------------------------------------------------------------
Below given example have 2 index, 2 nodes and 2 shards, each shard has replica on the other node so that in case of node failure the data isn’t lost 

![Fig ](/images/000001.png)

As we can see shards in node one denoted by 1... and 2.... * in node 2, have replicas in corresponding node, shards existing in node 2 have replicas in node 1 and shards in node 2 have replicas in node 2.

## Nodes Roles:

*	Master role
*	Data role
*	Ingest role
*	Machine learning role
*	Coordination role
*	Voting-only

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
It will involve in voting process but itself it can’t be master, only useful for large clusters.

## Snapshots
Snapshots used as term backups, we can take a snapshot of a node and cluster at given time, it will save all the data of a node including state(s).


# Queries

- PUT [index name]
-   -   PUT index_name
            {
            "settings": {
                "number_of_replicas": 3,
                "number_of_shards": 9
            }
            }

- DELETE [index name]


