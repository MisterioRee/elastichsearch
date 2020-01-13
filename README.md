<html><head><meta http-equiv="Content-Type" content="text/html;charset=utf-8" /> 
 
</head><body><div class="calibre" id="calibre_link-0">
	<h1 class="block_" id="calibre_link-1">Elasticsearch </h1>
	<p class="block_1">&nbsp;</p>
	<p class="block_2"></p>
	<p class="block_1">&nbsp;</p>
	<p class="block_2">Things are not that simple, Elastic urge to make replica for each node so in-case of hardware failure Elastic uses the replica and the data us not lost. By the way Elastic manage this by self, to in dig-in more each node is existing 2 or more (as many we want) times in form of replica.</p>
	<p class="block_2">Also, each node can have many shards, shards will allow node to divide data into multiple classifications which will improve search terminology.</p>
	<p class="block_2">Note: the replica is managed by Elastic itself.</p>
	<p class="block_1">&nbsp;</p>
	<img src="https://github.com/MisterioRee/elastichsearch/tree/master/images/000000.png" alt="Image" class="calibre1" />
	<p class="block_1">&nbsp;</p>
	<p class="block_2">Below given example have 2 index, 2 nodes and 2 shards, each shard has replica on the other node so that in case of node failure the data isn’t lost </p>
	<p class="block_1">&nbsp;</p>
	<p class="block_1">&nbsp;</p>
	<p class="block_1">&nbsp;</p>
	<h2 class="block_3" id="calibre_link-2"><img src="https://github.com/MisterioRee/elastichsearch/tree/master/images/000001.png" alt="Image" class="calibre1" /></h2>
	<p class="block_4">As we can see shards in node one denoted by 1. * and 2. * in node 2, have replicas in corresponding node, shards existing in node 2 have replicas in node 1 and shards in node 2 have replicas in node 2.</p>
	<h2 class="block_3" id="calibre_link-3">Nodes Roles:</h2>
	<p class="block_2">There are 3 type of role a node can perform</p>
	<ul class="list_">
	<li class="block_5">Master role</li>
	<li class="block_6">Data role</li>
	<li class="block_6">Ingest role</li>
	<li class="block_6">Machine learning role</li>
	<li class="block_6">Coordination role</li>
	<li class="block_7">Voting-only</li>
</ul>
	<h3 class="block_8" id="calibre_link-4">Master Node:</h3>
	<p class="block_4">There is always one super power as the nature of the world, somewhat here there is also one node we can assign to keep managing shards and replicas and other processes that is going to help to keep cluster healthy, the master is chosen via voting. We can set a master by command If there is no other master. (Recommended for large clusters)</p>
	<h3 class="block_8" id="calibre_link-5">Data Node:</h3>
	<p class="block_4">Being an organizer, it would be hard for a node to do 2 jobs or either it will affect the performance, or you want to keep data organized, you can set some nodes to save data only.</p>
	<h3 class="block_8" id="calibre_link-6">Ingest Role:</h3>
	<p class="block_4">It enables a node to run ingest pipelines, which means a series of processes that should be performed while indexing a document e.g. applying conditions or resolving Ip addresses.</p>
	<h3 class="block_8" id="calibre_link-7">Machine Learning Role:</h3>
	<p class="block_4">Enable or disable machine learning of a specific document.</p>
	<h3 class="block_8" id="calibre_link-8">Coordination Role:</h3>
	<p class="block_2">It refers to distribution and aggregation of query result.</p>
	<h3 class="block_8" id="calibre_link-9">Voting-Only Role:</h3>
	<p class="block_2">It will involve in voting process but itself it can’t be master, only useful for large clusters.</p>
	<p class="block_1">&nbsp;</p>
	<h2 class="block_3" id="calibre_link-10">Snapshots</h2>
	<p class="block_2">Snapshots used as term backups, we can take a snapshot of a node and cluster at given time, it will save all the data of a node including state(s).</p>
	<p class="block_1">&nbsp;</p>
	<p class="block_1">&nbsp;</p>
	<p class="block_2"> </p>
	<p class="block_1">&nbsp;</p>

</div>

</body></html>
