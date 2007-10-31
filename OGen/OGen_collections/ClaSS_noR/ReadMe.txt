ClaSS_noR: - Class State Serializer with no Reflection

- uses:

- does NOT use:
	- attributes
	- reflection

- advantages:
	- faster, but not by much
	- because it doesn't use attributes or reflection it should be
	more complicated to use, but it turned out to actually be more simple

- disadvantages:
	- it has a more complicate implementation