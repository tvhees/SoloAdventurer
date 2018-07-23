function describe()
  unity.Print("Script: Block_2. Adds 2 block to player.");
end

function execute(args)
  args.player:AddBlock(2);
  args.player:PlayCard(args.card);
end